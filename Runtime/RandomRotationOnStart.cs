using UnityEngine;

namespace Toolbox.Behaviours
{
    /// <summary>
    /// Applies a random local z-axis rotation ot an object once.
    /// </summary>
    [ExecuteInEditMode]
    public class RandomRotationOnStart : MonoBehaviour
    {
        void Start()
        {
            float a = Random.Range(0, 360);
            var angles = transform.localEulerAngles;
            angles.z = a;
            transform.localRotation = Quaternion.Euler(angles);

            Destroy(this);
        }
        
    }
}
