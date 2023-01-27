#if UNITY_EDITOR
using UnityEngine;

namespace Toolbox
{
    /// <summary>
    /// Handy component for adding 'comments' to a scene hierarchy.
    /// </summary>
    [ExecuteInEditMode]
    public class Comment : MonoBehaviour
    {
        #if UNITY_EDITOR
        [Tooltip("Should this comment self-destruct when loaded in-game?")]
        public bool DestroyOnStart = true;
        [Tooltip("Used as a safety precaution to avoid accidentally modifying a comment's text.")]
        public bool Lock;

        [Space(5)]
        [TextArea(5,45)]
        public string Text;
        string Backup;


        //TODO: have an option to display an in-editor popup when this Comment is enabled.


        void Awake()
        {
            if(Application.isPlaying) Destroy(this);
        }

        void Update()
        {
            if (Application.isPlaying) return;

            if (Lock) Text = Backup;
            else Backup = Text;
        }
        #endif
    }
}
#endif
