using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

#if TOOLBAR_EXTENDER
using UnityToolbarExtender;
#endif

namespace BK.Bootstrap.Editor
{
#if TOOLBAR_EXTENDER
    [InitializeOnLoad]
    public class EditorButtonHelper
    {
        static class ToolbarStyles
        {
            public static readonly GUIStyle commandButtonStyle;

            static ToolbarStyles()
            {
                commandButtonStyle = new GUIStyle("Command")
                {
                    fontSize = 12,
                    alignment = TextAnchor.MiddleCenter,
                    imagePosition = ImagePosition.ImageAbove,
                    margin = new RectOffset(),
                    padding = new RectOffset()
                };
                // commandButtonStyle.normal.background = GUI.skin.window.normal.background;
            }
        }

        static EditorButtonHelper()
        {
            ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
        }

        private static T[] GetAtPath<T>(string path)
        {
            ArrayList al = new ArrayList();
            string[] fileEntries = Directory.GetFiles(Application.dataPath + "/" + path);

            foreach (string fileName in fileEntries)
            {
                string temp = fileName.Replace("\\", "/");
                int index = temp.LastIndexOf("/");
                string localPath = "Assets/" + path;

                if (index > 0)
                    localPath += temp.Substring(index);

                Object t = AssetDatabase.LoadAssetAtPath(localPath, typeof(T));

                if (t != null)
                    al.Add(t);
            }

            T[] result = new T[al.Count];

            for (int i = 0; i < al.Count; i++)
                result[i] = (T)al[i];

            return result;
        }


        static void OnToolbarGUI()
        {
            GUILayout.FlexibleSpace();

            var targetFolder = "Scenes";

            if (!AssetDatabase.IsValidFolder(targetFolder))
                targetFolder = "#Scenes";

            if (GUILayout.Button(EditorGUIUtility.IconContent("UnityEditor.SceneHierarchyWindow"), ToolbarStyles.commandButtonStyle))
            {
                var a = new GenericMenu();

                var ls = GetAtPath<Object>(targetFolder);
                foreach (var l in ls)
                {
                    var p = AssetDatabase.GetAssetPath(l);
                    var n = Path.GetFileName(p);
                    if (n.EndsWith(".unity"))
                    {
                        a.AddItem(new GUIContent(Path.GetFileNameWithoutExtension(p)), false, () =>
                        {
                            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                            {
                                EditorSceneManager.OpenScene(p, OpenSceneMode.Single);
                                if (p == "bootstrap")
                                {
                                    Selection.activeGameObject = GameObject.FindGameObjectWithTag("Player");
                                    SceneView.FrameLastActiveSceneView();
                                }
                            }
                        });
                    }
                }
                a.ShowAsContext();
            }
            if (GUILayout.Button(EditorGUIUtility.IconContent("UnityEditor.GameView"), ToolbarStyles.commandButtonStyle))
            {
                if (!Application.isPlaying)
                    EditorSceneManager.OpenScene("Assets/" + targetFolder + "/bootstrap.unity", OpenSceneMode.Additive);
                Selection.activeGameObject = GameObject.FindGameObjectWithTag("Player");
                SceneView.FrameLastActiveSceneView();
            }

            GUILayout.Space(20);

        }
    }
#endif
}