using UnityEngine;
using System;
using System.Collections;

namespace Toolbox.Behaviours
{
    /// <summary>
    /// Used for handling timed callbacks using a coroutine. Must be invoked on an active object or it will puke errors.
    /// </summary>
    [AddComponentMenu("Toolbox/Common/Timed Event Handler")]
    public class TimedEventHandler : MonoBehaviour
    {
        IEnumerator HandleEvent(float delayInSec, object args, Action<object> callback)
        {
            if (delayInSec > 0.0f) yield return new WaitForSeconds(delayInSec);
            if (callback != null) callback.Invoke(args);
            yield return null;
        }

        IEnumerator HandleEvent<t>(float delayInSec, t arg, Action<t> callback)
        {
            if (delayInSec > 0.0f) yield return new WaitForSeconds(delayInSec);
            if (callback != null) callback.Invoke(arg);
            yield return null;
        }

        public void DoRoutine(float delayInSec, object args, Action<object> callback)
        {
            if (this.gameObject.activeInHierarchy) this.StartCoroutine(HandleEvent(delayInSec, args, callback));
        }

        public void DoRoutine<t>(float delayInSec, t arg, Action<t> callback)
        {
            if (this.gameObject.activeInHierarchy) this.StartCoroutine(HandleEvent(delayInSec, arg, callback));
        }

    }
}
