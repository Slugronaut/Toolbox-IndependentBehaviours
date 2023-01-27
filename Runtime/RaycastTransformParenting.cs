using UnityEngine;

namespace Toolbox.Behaviours
{
    /// <summary>
    /// Keeps a child transform in a position relative to a parent whilst
    /// adjusting it's local position relative to a raycats hit on a surface.
    /// </summary>
    public class RaycastTransformParenting : MonoBehaviour
    {
        public Transform Child;
        public Transform Parent;
        [Tooltip("How much offset to apply to the child's final determined position.")]
        public Vector3 ChildOffset;
        [Tooltip("How much offset to apply to the parent's position when starting the raycast.")]
        public Vector3 ParentOffset;
        public Vector3 RayDirection = Vector3.down;
        public float RayDistance = 3f;
        public float RayThickness = 0;

        public LayerMask Layers;
        [Tooltip("If set, when no surface is struck by the raycast the child stays at the last relative position, otherwise, it snaps back to the parent's center.")]
        public bool KeepLastPos = true;


        
        void Update()
        {
            var parentPos = Parent.position;
            bool hit = false;
            Vector3 p = Vector3.zero;
            RaycastHit rayhit;
            if (RayThickness <= 0.0f)
                hit = Physics.Raycast(parentPos + ParentOffset, RayDirection, out rayhit, RayDistance, Layers, QueryTriggerInteraction.Ignore);
            else hit = Physics.SphereCast(parentPos + ParentOffset, RayThickness, RayDirection, out rayhit, RayDistance, Layers, QueryTriggerInteraction.Ignore);

            if (hit)
                Child.position = rayhit.point + ChildOffset;
            else if (!KeepLastPos)
                Child.localPosition = ChildOffset;
           
        }
    }
}
