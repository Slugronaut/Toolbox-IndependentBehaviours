using UnityEngine;
using UnityEditor;
using Toolbox.Behaviours;


namespace Toolbox.ToolboxEditor
{
    [UnityEditor.CustomEditor(typeof(AudioSourceLoopPoints))]
    public class AudioSourceLoopPointsEditor : UnityEditor.Editor
    {
        AudioSourceLoopPoints Looper;
        AudioClip CurrentClip;
        Texture2D WaveForm;

        public void OnEnable()
        {
            Looper = target as AudioSourceLoopPoints;
        }

        public override void OnInspectorGUI()
        {
            if (Looper == null)
                return;

            var source = Looper.GetComponent<AudioSource>();
            if(source.clip == null)
            {
                EditorGUILayout.HelpBox("Requires an audio clip.", MessageType.None);
                return;
            }
            if(source.clip != CurrentClip)
            {
                CurrentClip = source.clip;
                WaveForm = AudioUtility.GetWaveForm(CurrentClip, 0, 500, 125);
            }

            Looper.StartPoint = EditorGUILayout.DoubleField("Start", Looper.StartPoint);
            Looper.LoopStart = EditorGUILayout.DoubleField("Coda Start", Looper.LoopStart);
            Looper.LoopEnd = EditorGUILayout.DoubleField("Coda End", Looper.LoopEnd);
            Looper.MaxLoops = EditorGUILayout.IntField("Number of Loops", Looper.MaxLoops);

            GUILayout.Space(20);
            var next = GUILayoutUtility.GetRect(Screen.width, 125);
            EditorGUI.DrawPreviewTexture(next, WaveForm, null, ScaleMode.StretchToFill);
        }
       
    }
}
