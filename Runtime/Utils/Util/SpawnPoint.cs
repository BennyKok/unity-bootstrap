using System.Collections;
using UnityEngine;

#if RUNTIME_DEBUG_SYSTEM
using BennyKok.RuntimeDebug.Systems;
using BennyKok.RuntimeDebug.Actions;
#endif

namespace BennyKok.Bootstrap
{
    public class SpawnPoint : MonoBehaviour
    {
        public int editorSpawnPoint;
        public int buildSpawnPoint;
        private GameObject player;

#if HAS_CINEMACHINE
        [Tooltip("To prevent cinemachine from moving too fast when teleporing")] public bool disableEnableCinemachine;
        private Cinemachine.CinemachineBrain brain;
#endif

        void Start()
        {
#if HAS_CINEMACHINE
            brain = Camera.main.gameObject.GetComponent<Cinemachine.CinemachineBrain>();
#endif

            player = GameObject.FindGameObjectWithTag("Player");
            if (!Application.isEditor)
            {
                editorSpawnPoint = buildSpawnPoint;
            }
            Move();
        }

        private void OnEnable()
        {
#if RUNTIME_DEBUG_SYSTEM
            RuntimeDebugSystem.RegisterActions("SpawnPoint",
                DebugActionBuilder.Button()
                .WithName("Reset Player Position")
                .WithAction(Move)
                .WithShortcutKey("1"),

                DebugActionBuilder.Button()
                 .WithName("Next Spawn Point")
                .WithAction(() =>
                {
                    editorSpawnPoint++;
                    if (editorSpawnPoint >= transform.childCount)
                    {
                        editorSpawnPoint = 0;
                    }
                    Move();
                })
                .WithShortcutKey("2")
            );
#endif
        }

        private void OnDisable()
        {
#if RUNTIME_DEBUG_SYSTEM
            RuntimeDebugSystem.UnregisterActionsByGroup("SpawnPoint");
#endif
        }

        private void Move()
        {
            StopCoroutine("MoveCoroutine");
            StartCoroutine("MoveCoroutine");
        }

        IEnumerator MoveCoroutine()
        {
#if HAS_CINEMACHINE
            var tempVCam = brain.ActiveVirtualCamera;
            if (disableEnableCinemachine)
            {
                tempVCam.VirtualCameraGameObject.SetActive(false);
            }
#endif
            yield return new WaitForEndOfFrame();

            player.transform.position = transform.GetChild(editorSpawnPoint).transform.position;
            player.transform.rotation = transform.GetChild(editorSpawnPoint).transform.rotation;

#if HAS_CINEMACHINE
            if (disableEnableCinemachine)
            {
                tempVCam.VirtualCameraGameObject.SetActive(true);
            }
#endif
        }
    }
}