using System;
using System.Collections.Generic;
using System.IO;
using Buildings;
using UnityEngine;

namespace AssetWorkflow
{
    public class BundlesManager : MonoBehaviour
    {
        public void Start() {
            var files = Directory.GetFiles(Path.Combine(Application.streamingAssetsPath, "buildings/civil/houses"));
            List<AssetBundle> bandles = new List<AssetBundle>();
            foreach(var f in files) {
                if (!Path.HasExtension(f)) {
                    AssetBundle bandle = AssetBundle.LoadFromFile(f);
                    Debug.Log(f);
                    if (bandle != null) {
                        bandles.Add(bandle);
                    }
                }
            }
        }
    }
}
