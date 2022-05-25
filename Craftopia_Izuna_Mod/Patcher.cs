using System;
using System.Reflection;
using BepInEx;
using HarmonyLib;

namespace Craftopia_Izuna_Mod
{
    [BepInPlugin(MOD_NAME, DISPLAY_NAME, VERSION)]
    public class Patcher : BaseUnityPlugin
    {
        public const String MOD_NAME = "net.muro1214.Craftpia_Izuna_Mod";
        public const String DISPLAY_NAME = "Craftpia_Izuna_Mod";
        public const String VERSION = "1.0.0";

        public void Awake()
        {
            var harmony = new Harmony(DISPLAY_NAME);
            harmony.PatchAll();
        }
    }
}
