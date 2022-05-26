using HarmonyLib;
using Oc;

namespace Craftopia_Izuna_Mod
{
    [HarmonyPatch(typeof(OcUtility), "getDropItem_BonusRate")]
    public class getDropItem_BonusRatePatch
    {
        public static void Postfix(ref float __result)
        {
            if (!Patcher.isEnabled_Item.Value)
            {
                return;
            }

            __result = Patcher.dropBonusRate.Value;
        }
    }
}
