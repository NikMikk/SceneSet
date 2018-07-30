#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

namespace SceneSet
{
    [CreateAssetMenu(menuName = "SceneSet")]
    public class SceneSet : ScriptableObject
    {
        public List<SceneAsset> scenesToLoad;

    }
}
#endif
