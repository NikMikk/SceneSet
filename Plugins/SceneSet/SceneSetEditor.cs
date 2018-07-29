#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(SceneSet))]
public class SceneSetEditor : Editor
{
    SceneSet myTarget;

    public override void OnInspectorGUI()
    {
        myTarget = (SceneSet)target;

        if (GUILayout.Button("Load Scenes") && myTarget.scenesToLoad != null)
            if (myTarget.scenesToLoad.Count == 0)
                Debug.LogError("Could not load SceneSet. \"" + myTarget.name + "\" contains no scenes");
            else
                LoadSceneSet(myTarget);

        DrawDefaultInspector();
    }

    public static void LoadSceneSet(SceneSet set)
    {
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
#endif