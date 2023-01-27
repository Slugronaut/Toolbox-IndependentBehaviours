using UnityEngine;
using System.Collections;


namespace Toolbox.Behaviours
{
    /// <summary>
    /// Sets the hideflags for this component's GameObject.
    /// Self destructs on Awake().
    /// </summary>
    [DisallowMultipleComponent]
    public sealed class SetHideFlags : MonoBehaviour
    {
        public HideFlags Flags;

        void Awake()
        {
            gameObject.hideFlags = Flags;
        }
    }
}
