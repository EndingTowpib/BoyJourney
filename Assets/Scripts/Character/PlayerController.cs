using System;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Character
{
    [RequireComponent(typeof(CharacterController2D))]
    public class PlayerController : MonoBehaviour
    {
        private CharacterController2D _mCharacterController;

        private void Awake()
        {
            _mCharacterController = GetComponent<CharacterController2D>();
            Debug.Assert(_mCharacterController);
        }

        private void Update()
        {
            ProcessInput();
        }

        private void ProcessInput()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float hSpeed = horizontalInput * _mCharacterController.GetHSpeedLimit();
            _mCharacterController.HSpeed = hSpeed;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _mCharacterController.Jump();
            }
        }
    }
}
