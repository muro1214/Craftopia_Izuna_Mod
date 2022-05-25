using HarmonyLib;
using Oc;
using Oc.Item;

namespace Craftopia_Izuna_Mod
{
    [HarmonyPatch(typeof(OcResidentData), "OnUnityAwake")]
    public class EnchantTemp
    {
        public static void Postfix(SoEnchantDataList ____enchantDataList)
        {
        //    foreach (SoEnchantment enchant in ____enchantDataList.GetAll())
        //    {
        //        UnityEngine.Debug.Log($"EnchantName {enchant.ID} : {enchant.DisplayName}");
        //    }
        }
    }
}
