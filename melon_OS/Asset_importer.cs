using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using MelonLoader.TinyJSON;
using static Mono.Security.X509.X520;

namespace melon_OS.Asset_Management
{
    public class Asset_importer
    {
        //private static int I;
        public static AssetBundle Init_bundle(string path)
        {
            var f = AssetBundle.LoadFromFile(path);
            //I++;
            MelonLogger.Msg("loaded AssetBundle: " + f.name);
            return f;
        }
        public static GameObject Logambundle(string path, string name)
        {
            var f = AssetBundle.LoadFromFile(path);
            //I++;
            MelonLogger.Msg("loaded AssetBundle: " + f.name);
            var MainResourcesAsset = f.LoadAsset<GameObject>(name);
            var g = new GameObject();

            if (MainResourcesAsset != null)
            {
                g = GameObject.Instantiate(MainResourcesAsset);
                

            }
            return g;
        }

    }
}
