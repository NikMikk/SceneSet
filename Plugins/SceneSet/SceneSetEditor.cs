#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace SceneSet
{
    [CustomEditor(typeof(SceneSet))]
    public class SceneSetEditor : Editor
    {
        static SceneSet myTarget;

        [OnOpenAssetAttribute()]
        static bool OnOpenAsset(int instanceID, int line)
        {
            if (Selection.activeObject == myTarget)
            {
                LoadSceneSet(myTarget);
                return true;
            }
            else
                return false;
        }

        public override void OnInspectorGUI()
        {
            myTarget = (SceneSet)target;

            if (GUILayout.Button("Load Scenes") && myTarget.scenesToLoad != null)
                LoadSceneSet(myTarget);

            DrawDefaultInspector();
        }

        public static void LoadSceneSet(SceneSet set)
        {
            if (myTarget.scenesToLoad == null || myTarget.scenesToLoad.Count == 0)
            {
                Debug.LogError("Could not load SceneSet. \"" + myTarget.name + "\" contains no scenes");
                return;
            }

            // Load the new scene
            EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(set.scenesToLoad[0]), OpenSceneMode.Single);

            // Add the other scenes to the newly loaded one
            for (int i = 1; i < set.scenesToLoad.Count; i++)
            {
                SceneAsset scene = set.scenesToLoad[i];
                EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(scene), OpenSceneMode.Additive);
            }
        }
    }
}
#endif