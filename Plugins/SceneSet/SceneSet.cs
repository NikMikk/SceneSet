#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CreateAssetMenu(menuName = "SceneSet")]
public class SceneSet : ScriptableObject
{
    public List<SceneAsset> scenesToLoad;
}
#endif
