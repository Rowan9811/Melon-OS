using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using melon_OS.Asset_Management;
using MelonLoader;
using UnityEngine;
using GorillaNetworking;
namespace melon_OS
{
    public class Main : MelonMod
    {
        //internal static List<AssetBundle>AssetBundles;
        private AssetBundle MainResources;
        private bool loaded;
        private GameObject computer;

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (buildIndex == 0) 
            { 
                MainResources = Asset_importer.Init_bundle(Application.streamingAssetsPath + "\\melon_OS\\required_assets\\main_resources"); 
            }
        }

        public override void OnUpdate()
        {
            MelonLogger.Msg(GorillaComputer.instance.currentQueue);
            MelonLogger.Msg(GorillaComputer.instance.currentGameMode);
            if (GorillaComputer.instance.currentQueue == "MINIGAMES" && GorillaComputer.instance.currentGameMode == "HUNT")
            {
                    GorillaComputer.instance.currentQueue = "DEFAULT";
                    GorillaComputer.instance.currentGameMode = "MODDED_CASUAL";
            }
            if (!loaded)
            { 
                if (MainResources != null) 
                {
                    
                    var MainResourcesAsset = MainResources.LoadAsset<GameObject>("pcg");
                
                
                    if (MainResourcesAsset != null)
                    {
                        GameObject.Instantiate(MainResourcesAsset);
                        loaded = true;
                        computer = GameObject.Find("-- PhysicalComputer UI --");

                        MeshRenderer meshRenderer = computer.GetComponentInChildren<MeshRenderer>();
                        Texture2D texture = new Texture2D(128, 128);
                        meshRenderer.material.mainTexture = texture;
                        for (int y = 0; y < texture.height; y++)
                        {
                            for (int x = 0; x < texture.width; x++)
                            {
                                Color color = new Color(136, 0, 255);
                                texture.SetPixel(x, y, color);
                                
                            }
                        }
                        texture.Apply();

                    }
                
                }
                else
                {
                    MelonLogger.Error("failed to load asset bundle");
                }
                loaded = true;
            }
        }


    }
}
