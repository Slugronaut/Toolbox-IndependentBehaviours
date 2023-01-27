using UnityEngine;
using System;

namespace Toolbox.Behaviours
{
    /// <summary>
    /// Can be used 'fake parent' one transform to another without actually
    /// having to make it a child.
    /// </summary>
    [ExecuteInEditMode]
    [DefaultExecutionOrder(1000)]
    public class PsuedoTransformParent : Sirenix.OdinInspector.SerializedMonoBehaviour
    {
        [Flags]
        public enum Flags : sbyte
        {
            UpdatePosition  =   1 << 0,
            UpdateRotation  =   1 << 1,
        }

        [Tooltip("The transform to which this object should pretend to be parented.")]
        public Transform Parent;
        
        [Sirenix.OdinInspector.ShowInInspector]
        public Vector3 localPosition
        {
            get { return _localPosition; }
            set { _localPosition = value; }
        }

        [Sirenix.OdinInspector.ShowInInspector]
        public Vector3 localRotation
        {
            get { return _localRotation.eulerAngles; }
            set { _localRotation.eulerAngles = value; }
        }

        [HideInInspector]
        [SerializeField]
        Quaternion _localRotation;

        [HideInInspector]
        [SerializeField]
        Vector3 _localPosition;

        [HideInInspector]
        [SerializeField]
        sbyte Sync;

        Transform Trans;

        [Sirenix.OdinInspector.PropertyTooltip("Shall the position be updated to match the parent's?")]
        [Sirenix.OdinInspector.ShowInInspector]
        public bool SyncPosition
        {
            get { return (Sync & (sbyte)Flags.UpdatePosition) > 0; }
            set
            {
                if (value)
                    Sync |= (sbyte)Flags.UpdatePosition;
                else Sync &= ~(sbyte)Flags.UpdatePosition;
            }
        }

        [Sirenix.OdinInspector.PropertyTooltip("Shall the rotation be updated to match the parent's?")]
        [Sirenix.OdinInspector.ShowInInspector]
        public bool SyncRotation
        {
            get { return (Sync & (sbyte)Flags.UpdateRotation) > 0; }
            set
            {
                if (value)
                    Sync |= (sbyte)Flags.UpdateRotation;
                else Sync &= ~(sbyte)Flags.UpdateRotation;
            }
        }



        protected void Awake()
        {
            Trans = transform;
        }

        void LateUpdate()
        {
            if (Parent == null)
                return;

            if(SyncRotation)
            {
                if (SyncPosition)
                    Trans.SetPositionAndRotation(Parent.position + localPosition, Parent.rotation * _localRotation);
                else Trans.rotation = Parent.rotation * _localRotation;
            }
            else
            {
                if (SyncPosition)
                    Trans.position = Parent.position + localPosition;
            }
        }
    }
}

