using UnityEngine;
using System;
using Sirenix.OdinInspector;


namespace Toolbox.Behaviours
{
    /// <summary>
    /// Each frame, sets the specified axies to have zero velocity on a given rigidbody.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class RemoveAxisVelocity : MonoBehaviour
    {
        [Flags]
        public enum Flags : sbyte
        {
            X = 1 << 0,
            Y = 1 << 1,
            Z = 1 << 2,
        }
        
        Rigidbody Body;

        [SerializeField]
        [HideInInspector]
        sbyte Vels;

        [PropertyTooltip("Update X rotation.")]
        [ShowInInspector]
        public bool UpdateX
        {
            get { return (Vels & (sbyte)Flags.X) > 0; }
            set
            {
                if (value)
                    Vels |= (sbyte)Flags.X;
                else Vels &= ~(sbyte)Flags.X;
            }
        }

        [PropertyTooltip("Update Y velocity.")]
        [ShowInInspector]
        public bool UpdateY
        {
            get { return (Vels & (sbyte)Flags.Y) > 0; }
            set
            {
                if (value)
                    Vels |= (sbyte)Flags.Y;
                else Vels &= ~(sbyte)Flags.Y;
            }
        }

        [PropertyTooltip("Update Z velocityn.")]
        [ShowInInspector]
        public bool UpdateZ
        {
            get { return (Vels & (sbyte)Flags.Z) > 0; }
            set
            {
                if (value)
                    Vels |= (sbyte)Flags.Z;
                else Vels &= ~(sbyte)Flags.Z;
            }
        }




        public void Awake()
        {
            Body = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            var oldVel = Body.velocity;

            Vector3 newVel = new Vector3(
                UpdateX ? 0 : oldVel.x,
                UpdateY ? 0 : oldVel.y,
                UpdateZ ? 0 : oldVel.z
                );

            Body.velocity = newVel;
        }
    }
}
