using UnityEngine;

namespace Toolbox.Behaviours
{
    /// <summary>
    /// Rotates an object over time.
    /// </summary>
    [ExecuteInEditMode]
    public class RotateObjectOverTime : MonoBehaviour
    {
        public Vector3 Speed;
#if UNITY_EDITOR
        [SerializeField]
#pragma warning disable 0649
        bool RotateInEditor;
#pragma warning restore 0649
#endif

        void Update()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying && !RotateInEditor)
                return;
#endif
            transform.Rotate(Speed * Time.deltaTime);
        }
    }
}