using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform targetObject;

        private void Awake()
        {
            Debug.Assert(targetObject);
        }

        private void LateUpdate()
        {
            transform.Translate(new Vector3(targetObject.position.x - transform.position.x,
                targetObject.position.y - transform.position.y, 0));
        }
    }
}
