using UnityEngine;

namespace Toolbox.Behaviours
{
    /// <summary>
    /// Rotates an object so that its forward vectors is aligned with its motion.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    [DisallowMultipleComponent]
    public class OrientForwardWithVelocity : MonoBehaviour
    {
        Rigidbody Body;

        void Start()
        {
            Body = GetComponent<Rigidbody>();
        }

        void LateUpdate()
        {
            transform.LookAt(Body.position + Body.velocity);
        }
    }
}
