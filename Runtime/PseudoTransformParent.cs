using UnityEngine;
using System;
using Sirenix.OdinInspector;

namespace Toolbox.Behaviours
{
    /// <summary>
    /// Can be used 'fake parent' one transform to another without actually
    /// having to make it a child.
    /// </summary>
    [ExecuteInEditMode]
    [DefaultExecutionOrder(1000)]
    public class PseudoTransformParent : SerializedMonoBehaviour
    {
        [Flags]
        public enum Flags : sbyte
        {
            UpdatePosition  =   1 << 0,
            UpdateRotation  =   1 << 1,
            SyncGlobalRotation = 1 << 2,
        }

        [Tooltip("The transform to which this object should pretend to be parented.")]
        public Transform Parent;
        
        [ShowInInspector]
        public Vector3 localPosition
        {
            get { return _localPosition; }
            set { _localPosition = value; }
        }

        [ShowInInspector]
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

        [PropertyTooltip("Shall the position be updated to match the parent's?")]
        [ShowInInspector]
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

        [PropertyTooltip("Shall the rotation be updated to match the parent's?")]
        [ShowInInspector]
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

        [PropertyTooltip("Shall the rotation sync with the parent's location rotation or global?")]
        [ShowInInspector]
        public bool UseGlobalRoation
        {
            get => (Sync & (sbyte)Flags.SyncGlobalRotation) > 0;
            set
            {
                if (value)
                    Sync |= (sbyte)Flags.SyncGlobalRotation;
                else Sync &= ~(sbyte)Flags.SyncGlobalRotation;
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
                var rot = UseGlobalRoation ? Parent.rotation : Parent.localRotation;
                if (SyncPosition)
                    Trans.SetPositionAndRotation(Parent.position + localPosition, rot * _localRotation);
                else Trans.rotation = rot * _localRotation;
            }
            else
            {
                if (SyncPosition)
                    Trans.position = Parent.position + localPosition;
            }
        }
    }
}

