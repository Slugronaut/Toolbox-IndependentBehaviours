using UnityEngine;

namespace Peg.Behaviours
{
    /// <summary>
    /// Facilitates the use of loop-points in an audio clip to allow
    /// intro sections that are only played once before looping overa coda.
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class AudioSourceLoopPoints : MonoBehaviour
    {
        public double StartPoint;
        public double LoopStart;
        public double LoopEnd = -1;
        public int MaxLoops = -1;

        int LoopCount = 0;
        AudioSource Source;


        void Start()
        {
            Source = GetComponent<AudioSource>();
            if (Source == null) Source = gameObject.AddComponent<AudioSource>();

            if(Source.playOnAwake) Source.PlayScheduled(AudioSettings.dspTime);
        }

        void Update()
        {
            if (Source == null || Source.clip == null || !Source.isPlaying) return;
            var clip = Source.clip;
            if ((float)Source.timeSamples < (StartPoint * clip.frequency) && LoopCount == 0)
                Source.timeSamples = (int)(StartPoint * clip.frequency);
            if (LoopEnd < 0) return;
            
            if (LoopEnd >= clip.length) LoopEnd = clip.length - 0.1;

            if (Source.timeSamples + 1.0f > LoopEnd * clip.frequency)
            {
                if ((MaxLoops >= 0 && LoopCount >= MaxLoops) || Source.loop == false)
                {
                    Source.Stop();
                    return;
                }
                
                LoopCount++;
                Source.timeSamples = (int)(LoopStart * clip.frequency);
            }

            
        }
    }
}