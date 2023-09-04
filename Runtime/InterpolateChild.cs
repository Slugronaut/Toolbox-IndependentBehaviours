using UnityEngine;
using Peg.Lib;

namespace Peg.Behaviours
{
    /// <summary>
    /// Causes a GameObject to interpolate its position based on its parent every frame.
    /// Running in 'fixed' mode will assume the parent is updating in FixedUpdate and will
    /// interpolate accordingly.
    /// </summary>
    public class InterpolateChild : MonoBehaviour
    {
        public UpdateTimingSmoothOnly UpdateAt;
        public Vector3 LocalOffset;
        public float SpeedX = 50.0f;
        public float SpeedY = 50.0f;
        public float SpeedZ = 50.0f;

        Vector3 LastParentPos;
        Vector3 MyLastPos;
        Transform Trans;
        Transform Parent;
        
        
        private void Start()
        {
            Trans = transform;
            Parent = transform.parent;
            LastParentPos = Parent.position;
            MyLastPos = Trans.position;
        }

        public void Sync()
        {
            LastParentPos = Parent.position;
            Trans.localPosition = LocalOffset;
            MyLastPos = Trans.position;
            Step();
        }

        public void Step()
        {
            var currParentPos = Parent.position;

            float x = MathUtils.SmoothApproach(MyLastPos.x, LastParentPos.x, currParentPos.x, SpeedX) + LocalOffset.x;
            float y = MathUtils.SmoothApproach(MyLastPos.y, LastParentPos.y, currParentPos.y, SpeedY) + LocalOffset.y;
            float z = MathUtils.SmoothApproach(MyLastPos.z, LastParentPos.z, currParentPos.z, SpeedZ) + LocalOffset.z;
            
            MyLastPos.x = x;
            MyLastPos.y = y;
            MyLastPos.z = z;
            Trans.position = MyLastPos;
            LastParentPos = currParentPos;
        }

        public void Update()
        {
            if (UpdateAt == UpdateTimingSmoothOnly.Update)
                Step();
        }

        public void LateUpdate()
        {
            if (UpdateAt == UpdateTimingSmoothOnly.LateUpdate)
                Step();
        }
    }
}
