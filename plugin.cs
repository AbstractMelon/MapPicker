using BepInEx;
using BoplFixedMath;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using Steamworks;
using Steamworks.Data;

namespace MapChoser
{
    [BepInPlugin("com.David_Loves_JellyCar_Worlds.MapPicker", "MapChoser", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Plugin MapChoser is loaded!");

            Harmony harmony = new Harmony("com.David_Loves_JellyCar_Worlds.MapChoser");

            Logger.LogInfo("harmany created");
            harmony.PatchAll();
            Logger.LogInfo("MapChoser Patch Compleate!");
        }


        [HarmonyPatch(typeof(GameSession))]
        public class myPatches
        {
            [HarmonyPatch("RandomBagLevel")]
            [HarmonyPostfix]
            private static void RandomBagLevel_MapChoser_Plug(GameSession __instance, ref byte ___currentLevel, ref int __result)
            {
                Debug.Log("random bag called");
                ___currentLevel = 1;
                __result = ___currentLevel;

            }
        }

    }
}
