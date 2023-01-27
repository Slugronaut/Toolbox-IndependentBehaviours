using UnityEngine;


namespace Toolbox.Behaviours
{
    /// <summary>
    /// Provides slight randomization to audio source clips by modulating their tone each time this object is activated.
    /// </summary>
    public class ModulateAudio : MonoBehaviour
    {
        public AudioSource Source;
        public float Min = 0.98f;
        public float Max = 1.02f;

        // Use this for initialization
        void OnEnable()
        {
            Source.pitch = Random.Range(Min, Max);
        }
    }
}
