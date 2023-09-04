using UnityEngine;
using UnityEngine.AI;



namespace Peg.Behaviours
{
    /// <summary>
    /// Rotates this object to face either left or right on the x-axis
    /// based on agent velocity.
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class RotateAgentTowardMotionAxis2D : MonoBehaviour
    {
        NavMeshAgent Agent;
        Transform Trans;

        void Start()
        {
            Agent = GetComponent<NavMeshAgent>();
            Trans = transform;
        }

        void LateUpdate()
        {
            if (Agent.velocity.x > Peg.Thresholds.Tenth)
                Trans.eulerAngles = new Vector3(0, 90, 0);
            else if (Agent.velocity.x < -Peg.Thresholds.Tenth)
                Trans.eulerAngles = new Vector3(0, -90, 0);
        }
    }
}
