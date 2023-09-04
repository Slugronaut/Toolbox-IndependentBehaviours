using UnityEngine;


namespace Peg.Behaviours
{
    /// <summary>
    /// Simply spawns an object in the location of this component.
    /// </summary>
    public class SpawnInPlace : MonoBehaviour
    {
        public GameObject Prefab;
        public EventAndCollisionTiming Trigger;
        public bool ParentSpawned = false;
        public float Delay = 0;

        static string DelayedSpawnFunc = "DelayedSpawn";

        void Awake()
        {
            if (Trigger == EventAndCollisionTiming.Awake)
                SpawnPrefab();
        }

        void Start()
        {
            if (Trigger == EventAndCollisionTiming.Start)
                SpawnPrefab();
        }

        void OnEnable()
        {
            if (Trigger == EventAndCollisionTiming.Enable)
                SpawnPrefab();
        }

        void OnDisable()
        {
            if (Trigger == EventAndCollisionTiming.Disable)
                SpawnPrefab();
        }

        void OnDestroy()
        {
            if (Trigger == EventAndCollisionTiming.Destroy)
                SpawnPrefab();
        }

        #if TOOLBOX_2DCOLLIDER
        void OnTriggerEnter2D(Collider2D other)
        {
            if (Trigger == EventAndCollisionTiming.Awake)
                SpawnPrefab();
        }
        #else
        void OnTriggerEnter(Collider other)
        {
            if (Trigger == EventAndCollisionTiming.Awake)
                SpawnPrefab();
        }
        #endif

        void OnRelenquish()
        {
            if (Trigger == EventAndCollisionTiming.Relenquished)
                SpawnPrefab();
        }

        /// <summary>
        /// 
        /// </summary>
        void SpawnPrefab()
        {
            if (Delay > 0)
                DelayedSpawn();
            else Invoke(DelayedSpawnFunc, Delay);
        }

        void DelayedSpawn()
        {
            var go = Instantiate(Prefab);
            go.transform.position = transform.position;

            if (ParentSpawned)
                go.transform.SetParent(transform, true);
        }
    }
}
