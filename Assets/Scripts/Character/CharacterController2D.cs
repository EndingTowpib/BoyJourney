using System;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Rigidbody2D),typeof(SpriteRenderer))]
    public class CharacterController2D : MonoBehaviour
    {
        private Rigidbody2D _mRigidbody;
        private SpriteRenderer _mSpriteRenderer;
        private Animator _mAnimator;

        public bool IsGrounded => _mGroundHitInfo;
        
        [SerializeField]
        private Transform groundCheckObject;
        private RaycastHit2D _mGroundHitInfo;
        private int _mEnvLayerMask;

        [SerializeField] private float maxHSpeed = 5.0f;
        [SerializeField] private float maxVSpeed = 10.0f;
        [SerializeField] private float jumpSpeed = 8.0f;
        [SerializeField] private float gravity = -9.8f;
        
        // half time of whole jumping cycle
        private float _mT0;

        private float _mHSpeed;
        private float _mVSpeed;

        private float _mTimeSinceLeavingGround;
        private float _mTimeSinceIdle;
        [SerializeField] private float blinkBreak = 2.0f;

        private bool _mIsFaceRight = true;
        
        // to indicate that the Floating character is jumping but not just falling down
        private bool _mJumpFlag = false;

        [SerializeField] private uint airMaxDashCount = 1;
        private uint _mCurrentDashCount;
        private bool _mIsDashing = false;
        [SerializeField] private float dashSpeed = 20.0f;
        
        private static readonly int AnimHSpeed = Animator.StringToHash("HSpeed");
        private static readonly int AnimVSpeed = Animator.StringToHash("VSpeed");
        private static readonly int AnimIsGrounded = Animator.StringToHash("IsGrounded");
        private static readonly int AnimBlink = Animator.StringToHash("Blink");
        private static readonly int AnimIsDashing = Animator.StringToHash("IsDashing");

        private void Awake()
        {
            _mRigidbody = GetComponent<Rigidbody2D>();
            Debug.Assert(_mRigidbody);
            _mSpriteRenderer = GetComponent<SpriteRenderer>();
            Debug.Assert(_mSpriteRenderer);
            _mAnimator = GetComponent<Animator>();
            Debug.Assert(_mAnimator);
            Debug.Assert(groundCheckObject);
            _mEnvLayerMask = 1 << LayerMask.NameToLayer("Env");

            _mT0 = 0.4f;
        }

        private void Start()
        {
            _mCurrentDashCount = airMaxDashCount;
        }

        private void FixedUpdate()
        {
            // detect grounded or not
            bool lastFrameGrounded = IsGrounded;
            _mGroundHitInfo = Physics2D.Linecast(transform.position, groundCheckObject.position,
                _mEnvLayerMask);
            if (!lastFrameGrounded && IsGrounded)
            {
                OnLandingGround();
            }else if (lastFrameGrounded && !IsGrounded)
            {
                OnLeavingGround();
            }
            
            // the Y velocity when character is in air
            if (!IsGrounded && !_mIsDashing)
            {
                _mTimeSinceLeavingGround += Time.fixedDeltaTime;

                if (_mJumpFlag && _mTimeSinceLeavingGround < 2 * _mT0) // jump calculate
                    _mVSpeed = jumpSpeed * Mathf.Cos(Mathf.PI * _mTimeSinceLeavingGround / (2.0f * _mT0));
                else    // fall calculate
                {
                    _mVSpeed += gravity * Time.deltaTime;
                }
            }

            // tick blink animation
            if (Mathf.Abs(_mHSpeed) < 1e-5)
            {
                _mTimeSinceIdle += Time.fixedDeltaTime;
                if (_mTimeSinceIdle >= blinkBreak)
                {
                    _mTimeSinceIdle -= blinkBreak;
                    _mAnimator.SetTrigger(AnimBlink);
                }
            }
            else
                _mTimeSinceIdle = 0;
            

            _mRigidbody.velocity = new Vector2(_mHSpeed,Mathf.Clamp(_mVSpeed,-maxVSpeed, maxVSpeed));

            if (_mHSpeed < 0 && _mIsFaceRight || _mHSpeed >0 && !_mIsFaceRight)
            {
                FlipCharacter();
            }
            
        }

        private void Update()
        {
            _mAnimator.SetFloat(AnimHSpeed,Mathf.Abs(_mHSpeed));
            _mAnimator.SetFloat(AnimVSpeed, _mVSpeed);
            _mAnimator.SetBool(AnimIsGrounded,IsGrounded);
            _mAnimator.SetBool(AnimIsDashing,_mIsDashing);
        }

        private void OnDrawGizmos()
        {
            Debug.DrawLine(transform.position, groundCheckObject.position, Color.magenta);
        }

        private void FlipCharacter()
        {
            _mIsFaceRight = !_mIsFaceRight;
            _mSpriteRenderer.flipX = !_mSpriteRenderer.flipX;
        }

        private void OnLandingGround()
        {
            _mVSpeed = 0;
            
            _mJumpFlag = false;

            _mCurrentDashCount = airMaxDashCount;
        }

        private void OnLeavingGround()
        {
            _mTimeSinceLeavingGround = 0;
        }
        
        // -----------------------------------INTERFACE--------------------------------------
        
        // get the horizontal speed limit to map the -1.0 ~ 1.0 input into -MaxSpeed ~ MaxSpeed
        public void UpdateHSpeed(float input)
        {
            if(!_mIsDashing)
                _mHSpeed = input * maxHSpeed;
        }

        // jump function called by player controller
        public void Jump()
        {
            if (!IsGrounded)
            {
                return;
            }

            _mJumpFlag = true;
            _mVSpeed = jumpSpeed;
        }

        public void Dash()
        {
            if (_mIsDashing || !IsGrounded && _mCurrentDashCount == 0)
            {
                return;
            }

            _mIsDashing = true;
            if(!IsGrounded)
                _mCurrentDashCount--;

            _mJumpFlag = false;
            _mHSpeed = _mIsFaceRight ? dashSpeed : -dashSpeed;
            _mVSpeed = 0;
            
        }

        public void EndDash()
        {
            _mIsDashing = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!_mIsDashing)
                return;
            
            var contacts = other.contacts;
            foreach (var contact in contacts)
            {
                if (Mathf.Abs(contact.normal.normalized.x) > 0.2f)
                {
                    EndDash();
                    Debug.Log("Hit something and stop dash");
                    break;
                }
            }
        }
    }
}
