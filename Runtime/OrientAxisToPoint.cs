using UnityEngine;
using System.Collections;

namespace Peg.Behaviours
{
    /// <summary>
    /// Rotates a single axis towards a point in 2D space.
    /// NOTE: currently only rotates on z-axis to point at a location on the x/y.
    /// </summary>
    public class OrientAxisToPoint : MonoBehaviour
    {
        public bool TargetIsMouse = false;
        public Vector2 FaceTowards;
        public float RotateSpeed = 1000;
        

        void Awake()
        {
            //initialize us as facing south
            FaceTowards = (Vector2)transform.position - Vector2.up;
        }

        void Update()
        {
            if (TargetIsMouse)
            {
                Vector3 mPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f);
                FaceTowards = Camera.main.ScreenToWorldPoint(mPos);
            }

            Vector2 dir = (Vector2)transform.position - FaceTowards;
            float rot = -Mathf.Atan2(dir.x, dir.y) * 180 / Mathf.PI;
            float newZ = Mathf.MoveTowardsAngle(transform.localEulerAngles.z, rot, RotateSpeed * Time.deltaTime);
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, newZ);
        }
        
    }
}
