using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

namespace Toolbox.Behaviours
{
    public class TallyKeeper : MonoBehaviour
    {
        [ReadOnly]
        public byte Tally;
        public byte Target = 1;
        public UnityEvent OnTallyTarget;

        public void Increment()
        {
            Tally++;
            if (Tally >= Target)
                OnTallyTarget.Invoke();
        }
    }
}
