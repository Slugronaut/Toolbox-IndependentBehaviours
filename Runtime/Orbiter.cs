using UnityEngine;

namespace Toolbox.Behaviours
{
    /// <summary>
    /// Makes this object orbit around another Transform.
    /// </summary>
    [DisallowMultipleComponent]
    public class Orbiter : MonoBehaviour
    {
        public Vector3 RotateSpeed;
        public Transform Center;
        

        void LateUpdate()
        {
            Vector3 angles = transform.eulerAngles;
            angles.z = 0;
            transform.eulerAngles = angles;
            Vector3 p = Center.position;
            float t = Time.deltaTime;
            transform.RotateAround(p, Vector3.up, RotateSpeed.x * t);
            transform.RotateAround(p, Vector3.right, RotateSpeed.y * t);
            transform.RotateAround(p, Vector3.forward, RotateSpeed.z * t);
            transform.LookAt(Center);
        }
        
    }
}
