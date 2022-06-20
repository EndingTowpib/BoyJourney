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
            _mCharacterController.UpdateHSpeed(horizontalInput);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _mCharacterController.Jump();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                _mCharacterController.Dash();
            }
        }
    }
}
