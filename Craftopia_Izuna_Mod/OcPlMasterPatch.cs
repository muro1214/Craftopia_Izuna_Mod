using HarmonyLib;
using Oc;

namespace Craftopia_Izuna_Mod
{
    [HarmonyPatch(typeof(OcPlMaster), "changeDurability_Item")]
    public class changeDurability_ItemPatch
    {
        public static bool Prefix()
        {
            if (!Patcher.isEnabled_Master.Value)
            {
                return true;
            }

            return false;
        }
    }
}
