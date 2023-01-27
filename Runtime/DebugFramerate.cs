using UnityEngine;


namespace Toolbox.Behaviours
{
    /// <summary>
    /// Can be used to limit the framerate in a debug build of the game, making it easier to observe the profiler in real time.
    /// </summary>
    public class DebugFramerate : MonoBehaviour
    {
        public int DesiredFramerate = 60;

        private void OnEnable()
        {
            if(Debug.isDebugBuild)
                Application.targetFrameRate = DesiredFramerate;
        }
    }
}
