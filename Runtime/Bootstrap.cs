﻿using UnityEngine;
using UnityEngine.SceneManagement;

namespace BK.Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        [Tooltip("Load any scene with the same name with a suffice of \"_data\"")]
        public bool loadDataScene;

        private void Awake()
        {
            var bootstrapLoaded = false;
            var dataSceneLoaded = false;
            var dataSceneName = gameObject.scene.name + "_data";

            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var o = SceneManager.GetSceneAt(i);
                if (o.name == "bootstrap")
                {
                    bootstrapLoaded = true;
                }
                if (o.name == dataSceneName)
                {
                    dataSceneLoaded = true;
                    break;
                }
            }

            if (!bootstrapLoaded)
                SceneManager.LoadScene("bootstrap", LoadSceneMode.Additive);

            if (!dataSceneLoaded && loadDataScene)
            {
                // //Not editor, or in editor and preview enabled
                // if (!Application.isEditor || (Application.isEditor && previewInGame))
                // {
                SceneManager.LoadScene(dataSceneName, LoadSceneMode.Additive);
                // }
            }
        }
    }
}