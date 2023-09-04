using UnityEngine;


namespace Peg.Behaviours
{
    /// <summary>
    /// Simple component that moves an object in a straight line with a given velocity.
    /// </summary>
    public class MoveInLine : MonoBehaviour
    {
        public Vector3 Velocity;
        Transform Trans;

        void Awake()
        {
            Trans = transform;
        }

        void Update()
        {
            Trans.position += Velocity * Time.deltaTime;
        }
    }
}
