using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Peg.Behaviours
{
    /// <summary>
    /// Simple device used to display framerate. For dev-use only due to performance reasons.
    /// </summary>
    [AddComponentMenu("Toolbox/Common/Frames-Per-Second Display")]
    public class FPSDisplay : MonoBehaviour
    {
        public Text Display;
        public bool UseOldUI = false;

        public float updateInterval = 0.25F;
        private double lastInterval;
        private int frames = 0;
        private float fps;

        void Start()
        {
            lastInterval = Time.realtimeSinceStartup;
            frames = 0;
        }

        void OnGUI()
        {
            if(UseOldUI) GUILayout.Label("" + fps.ToString("f2"));
        }

        void Update()
        {
            ++frames;
            float timeNow = Time.realtimeSinceStartup;
            if (timeNow > lastInterval + updateInterval)
            {
                fps = (float)(frames / (timeNow - lastInterval));
                frames = 0;
                lastInterval = timeNow;
                if (Display != null) Display.text = Mathf.RoundToInt(fps).ToString();
            }
        }

    }
}