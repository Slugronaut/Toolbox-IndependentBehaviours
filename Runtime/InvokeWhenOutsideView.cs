using Peg.Lib;
using UnityEngine;
using UnityEngine.Events;

namespace Peg.Behaviours
{
    /// <summary>
    /// Invokes a UnityEvent when this object is outside a viewport.
    /// </summary>
    public class InvokeWhenOutsideView : MonoBehaviour
    {
        [Tooltip("Optional camera. If not specified, the main camera is used.")]
        public Camera Cam;
        public float Cooldown;
        public UnityEvent OnOffscreen;
        public UnityEvent OnOnScreen;

        float LastTime;
        Transform Trans;
        public float xSafety, ySafety;


        private void Start()
        {
            Trans = transform;
            if (Cam == null)
                Cam = Camera.main;
        }

        private void OnEnable()
        {
            LastTime = Time.time;
        }

        private void Update()
        {
            if(Time.time - LastTime > Cooldown)
            {
                LastTime = Time.time;
                if (!MathUtils.IsInViewport(Cam, Trans.position, xSafety, ySafety))
                    OnOffscreen.Invoke();
                else OnOnScreen.Invoke();
            }
        }


    }
}
