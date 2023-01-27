using System;
using UnityEngine;
using Sirenix.OdinInspector;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Toolbox
{
    /// <summary>
    /// Generates a GUID upon awakening.
    /// </summary>
    [DisallowMultipleComponent]
    public class GuidComponent : MonoBehaviour
    {
        public Guid Guid { get; private set; }

        #if UNITY_EDITOR
        [ShowInInspector]
        [CustomValueDrawer("DrawGuid")]
        string GuidId = new Guid().ToString();

        static string DrawGuid(string guid, GUIContent label)
        {
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.TextField("Guid", guid.ToString());
            EditorGUI.EndDisabledGroup();
            return guid;
        }
        #endif

        void Awake()
        {
            Guid = Guid.NewGuid();
            GuidId = Guid.ToString();
        }

    }
}
