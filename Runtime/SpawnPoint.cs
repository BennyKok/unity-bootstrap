using System.Collections;
using UnityEngine;

#if RUNTIME_DEBUG
using BK.RuntimeDebug;
#endif

namespace BennyKok.Bootstrap
{
    public class SpawnPoint : MonoBehaviour
    {
        public int editorSpawnPoint;
        public int buildSpawnPoint;
        private GameObject player;

        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (!Application.isEditor)
            {
                editorSpawnPoint = buildSpawnPoint;
            }
            Move();
        }

        private void OnEnable()
        {
#if RUNTIME_DEBUG
            RuntimeDebugSystem.RegisterActions("Core",
                new RuntimeDebugAction("Reset Player Position", "1", () =>
                {
                    Move();
                }),
                new RuntimeDebugAction("Next Spawn Point", "2", () =>
                {
                    editorSpawnPoint++;
                    if (editorSpawnPoint >= transform.childCount)
                    {
                        editorSpawnPoint = 0;
                    }
                    Move();
                })
            );
#endif
        }

        private void OnDisable()
        {
#if RUNTIME_DEBUG
            RuntimeDebugSystem.UnregisterActionByTag("SpawnPoint");
#endif
        }

        private void Move()
        {
            StopCoroutine("MoveCoroutine");
            StartCoroutine("MoveCoroutine");
        }

        IEnumerator MoveCoroutine()
        {
            yield return new WaitForEndOfFrame();
            player.transform.position = transform.GetChild(editorSpawnPoint).transform.position;
            player.transform.rotation = transform.GetChild(editorSpawnPoint).transform.rotation;
        }
    }
}