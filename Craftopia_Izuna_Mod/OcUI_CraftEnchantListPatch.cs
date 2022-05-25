using HarmonyLib;
using Oc.Item.UI;
using System.Collections.Generic;
using System.Linq;
using TMPro;

namespace Craftopia_Izuna_Mod
{
    [HarmonyPatch(typeof(OcUI_CraftEnchantList), "TryLockEnchant")]
    public class TryLockEnchantPatch
    {
        public static bool Prefix(OcUI_CraftEnchantList __instance, OcUI_CraftEnchantSheet ___selectingSheet, ref int ____lockCount)
        {
			if (___selectingSheet == null)
			{
				return false;
			}

			if (___selectingSheet.Chosen)
			{
				___selectingSheet.SwitchChoose(false);
				____lockCount--;
			}
			else if (____lockCount < 4)
			{
				___selectingSheet.SwitchChoose(true);
				____lockCount++;
			}

			__instance.Sort();
			__instance.Refresh();
			AccessTools.Method(__instance.GetType(), "RefreshPurchasePrice").Invoke(__instance, null);

			return false;
		}
    }

	[HarmonyPatch(typeof(OcUI_CraftEnchantList), "Sort")]
	public class SortPatch
    {
		public static void Postfix(OcUI_CraftEnchantSheet ___fixedEnchantSheet)
        {
			___fixedEnchantSheet.gameObject.SetActive(false);

		}
    }

	[HarmonyPatch(typeof(OcUI_CraftEnchantList), "Refresh")]
	public class RefreshPatch
	{
		public static void Postfix(TextMeshProUGUI ___price)
		{
			___price.text = "0";
		}
	}

	[HarmonyPatch(typeof(OcUI_CraftEnchantList), "GetLockedEnchantID")]
    public class GetLockedEnchantIDPatch
    {
        public static bool Prefix(ref int[] __result, int ____lockCount, List<OcUI_CraftEnchantSheet> ___itemEnchantList)
        {

			int[] array = new int[4];
			if (____lockCount == 0)
			{
				__result = array;
				return false;
			}
			IEnumerable<OcUI_CraftEnchantSheet> enumerable = from sheet in ___itemEnchantList
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
