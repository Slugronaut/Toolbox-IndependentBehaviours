using Sirenix.OdinInspector;
using UnityEngine;

namespace Toolbox.Behaviours
{
    /// <summary>
    /// Used to freeze various aspects of a Transform. Useful
    /// for keeping world-orientations when an object is parented
    /// to something that moves and rotates.
    /// </summary>
    [DisallowMultipleComponent]
    public class FreezeTransform : MonoBehaviour
    {
        [Tooltip("If true, this object will keep its world-axis relative position to its parent, even when the parent rotates.")]
        public bool KeepRelativePosition = false;
        [ShowIf("KeepRelativePosition")]
        [Indent]
        public Vector3 Position;

        public bool FreezeRotation;
        [ShowIf("FreezeRotation")]
        [Indent]
        public Vector3 Rotation;


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
            if (FreezeRotation) Trans.rotation = Quaternion.Euler(Rotation);
        }
    }
}
