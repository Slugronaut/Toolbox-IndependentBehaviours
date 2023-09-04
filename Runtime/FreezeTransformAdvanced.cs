using UnityEngine;
using Sirenix.OdinInspector;

namespace Peg.Behaviours
{
    /// <summary>
    /// Used to freeze various aspects of a Transform. Useful
    /// for keeping world-orientations when an object is parented
    /// to something that moves and rotates.
    /// </summary>
    [DisallowMultipleComponent]
    public class FreezeTransformAdvanced : MonoBehaviour
    {
        public enum Axies
        {
            None = 0,
            X = 1,
            Y = 2,
            Z = 4,
            All = X | Y | Z,
        }
        [Tooltip("If true, this object will keep its world-axis relative position to its parent, even when the parent rotates.")]
        public bool KeepRelativePosition = false;
        [ShowIf("KeepRelativePosition")]
        [Indent]
        public Vector3 Position;

        public bool FreezeRotation;
        [ShowIf("FreezeRotation")]
        [Indent]
        public Vector3 Rotation;
        [MaskedEnum]
        [ShowIf("FreezeRotation")]
        [Indent]
        public Axies RotFreeze;

        
        Transform Trans;
        Transform Parent;


        void Awake()
        {
            Position = transform.localPosition;
            Trans = transform;
            Parent = Trans.transform.parent;
        }

        private void LateUpdate()
        {
            if (KeepRelativePosition) Trans.position = Parent.position + Position;

            if(FreezeRotation)
            {
                Vector3 local = Trans.rotation.eulerAngles;

                if ((RotFreeze & Axies.X) != 0)
                    local.x = Rotation.x;

                if ((RotFreeze & Axies.Y) != 0)
                    local.y = Rotation.y;

                if ((RotFreeze & Axies.Z) != 0)
                    local.z = Rotation.z;

                Trans.rotation = Quaternion.Euler(local);
            }

        }
    }
}
