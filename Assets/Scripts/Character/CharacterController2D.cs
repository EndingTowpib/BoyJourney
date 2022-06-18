using System;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Rigidbody2D),typeof(SpriteRenderer))]
    public class CharacterController2D : MonoBehaviour
    {
        private Rigidbody2D _mRigidbody;
        private SpriteRenderer _mSpriteRenderer;

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
        
        public float HSpeed
        {
            get => _mHSpeed;
            set => _mHSpeed = Mathf.Clamp(value, -maxHSpeed, maxHSpeed);
        }

        public float VSpeed
        {
            get => _mVSpeed;
            set => _mVSpeed = Mathf.Clamp(value, -maxVSpeed, maxVSpeed);
        }

        private bool _mFaceRight = true;
        
        // to indicate that the Floating character is jumping but not just falling down
        private bool _mJumpFlag = false; 

        private void Awake()
        {
            _mRigidbody = GetComponent<Rigidbody2D>();
            Debug.Assert(_mRigidbody);
            _mSpriteRenderer = GetComponent<SpriteRenderer>();
            Debug.Assert(_mSpriteRenderer);
            Debug.Assert(groundCheckObject);
            _mEnvLayerMask = 1 << LayerMask.NameToLayer("Env");

            _mT0 = 0.4f;
        }

        private void FixedUpdate()
        {
            bool lastFrameGrounded = IsGrounded;
            _mGroundHitInfo = Physics2D.Linecast(transform.position, groundCheckObject.position,
                _mEnvLayerMask);
            if (!lastFrameGrounded && IsGrounded)
            {
                OnLandingGround();
            }
            
            if (!IsGrounded)
            {
                _mTimeSinceLeavingGround += Time.fixedDeltaTime;

                if (_mJumpFlag && _mTimeSinceLeavingGround < 2 * _mT0) // jump calculate
                    VSpeed = jumpSpeed * Mathf.Cos(Mathf.PI * _mTimeSinceLeavingGround / (2.0f * _mT0));
                else    // fall calculate
                {
                    VSpeed += gravity * Time.deltaTime;
                }
            }

            _mRigidbody.velocity = new Vector2(HSpeed, VSpeed);

            if (HSpeed < 0 && _mFaceRight || HSpeed >0 && !_mFaceRight)
            {
                _mFaceRight = !_mFaceRight;
                FlipRenderer();
            }
            
        }
        
        private void OnDrawGizmos()
        {
            Debug.DrawLine(transform.position, groundCheckObject.position, Color.magenta);
        }

        private void FlipRenderer()
        {
            _mSpriteRenderer.flipX = !_mSpriteRenderer.flipX;
        }

        private void OnLandingGround()
        {
            VSpeed = 0;

            _mTimeSinceLeavingGround = 0;
            _mJumpFlag = false;
        }
        
        // -----------------------------------INTERFACE--------------------------------------
        
        // get the horizontal speed limit to map the -1.0 ~ 1.0 input into -MaxSpeed ~ MaxSpeed
        public float GetHSpeedLimit() => maxHSpeed;

        // jump function called by player controller
        public void Jump()
        {
            if (!IsGrounded)
            {
                return;
            }

            _mJumpFlag = true;
            VSpeed = jumpSpeed;
        }
    }
}
