using HarmonyLib;
using Oc.Item.UI;
using System.Collections.Generic;
using System.Linq;

namespace Craftopia_Izuna_Mod
{
    [HarmonyPatch(typeof(OcUI_CraftEnchantList), "TryLockEnchant")]
    public class TryLockEnchantPatch
    {
        public static void Postfix(ref OcUI_CraftEnchantList __instance)
        {
            __instance.PurchaseCost = 0;
        }
    }

    [HarmonyPatch(typeof(OcUI_CraftEnchantList), "GetLockedEnchantID")]
    public class GetLockedEnchantIDPatch
    {
        public static bool Prefix(ref OcUI_CraftEnchantList __instance, ref int[] __result)
        {

			int[] array = new int[4];
			if (__instance._lockCount == 0)
			{
				__result = array;
				return false;
			}
			IEnumerable<OcUI_CraftEnchantSheet> enumerable = from sheet in __instance.itemEnchantList
															 where sheet.Chosen
															 select sheet;
			int num = 0;
			foreach (OcUI_CraftEnchantSheet ocUI_CraftEnchantSheet in enumerable)
			{
				array[num] = ocUI_CraftEnchantSheet.EnchantID;
				num++;
				if (num >= 4)
				{
					__result = array;
					return false;
				}
			}

			__result = array;
			return false;
        }
    }
}
