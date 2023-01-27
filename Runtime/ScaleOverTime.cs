using UnityEngine;


namespace Toolbox.Behaviours
{
    /// <summary>
    /// Scales an object while it is active.
    /// </summary>
    public class ScaleOverTime : MonoBehaviour
    {
        public Vector3 Start;
        public Vector3 End;
        public float ScaleTime = 1;

        float StartTime;
        Vector3 Vel;
        Transform Trans;

        private void Awake()
        {
            Trans = transform;
        }

        private void OnEnable()
        {
            Trans.localScale = Start;
            Vel = (End - Start) / ScaleTime;
            StartTime = Time.time;
        }

        private void OnDisable()
        {
            Trans.localScale = Start;
        }

        void Update()
        {
            if(Time.time - StartTime < ScaleTime)
                Trans.localScale += Vel * Time.deltaTime;
        }
    }
}
