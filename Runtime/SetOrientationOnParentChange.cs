using UnityEngine;

namespace Peg.Behaviours
{
    /// <summary>
    /// Sets the specified transform's rotation when this gameobject's parent changes.
    /// </summary>
    public class SetOrientationOnParentChange : MonoBehaviour
    {
        public Transform Trans;
        public Vector3 Rotation;
        public Space RotationSpace;


        public void OnTransformParentChanged()
        {
            if (RotationSpace == Space.Self)
                Trans.localRotation = Quaternion.Euler(Rotation);
            else Trans.rotation = Quaternion.Euler(Rotation);
        }
    }
}
