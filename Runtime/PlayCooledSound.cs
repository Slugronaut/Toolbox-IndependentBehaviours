using UnityEngine;

namespace Toolbox.Behaviours
{
    /// <summary>
    /// Can be linked to events to play a sound with a cooldown period.
    /// </summary>
    public class PlayCooledSound : MonoBehaviour
    {
        public float Cooldown;
        public AudioSource Source;

        float LastTime;

        public void Play(AudioClip clip)
        {
            float t = Time.time;
            if(t - LastTime > Cooldown)
            {
                LastTime = t;
                Source.PlayOneShot(clip);
            }
        }

    }
}
