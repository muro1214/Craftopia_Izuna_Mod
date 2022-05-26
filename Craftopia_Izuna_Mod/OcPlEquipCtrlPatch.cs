using HarmonyLib;
using Oc;
using Oc.Item;
using UnityEngine;

namespace Craftopia_Izuna_Mod
{
    [HarmonyPatch(typeof(OcPlEquipCtrl), "UpdateEquip")]
    public class UpdateEquipPatch
    {
        public static void Postfix(OcItem item, OcEquipSlot equipSlot, OcPlEquipCtrl __instance)
        {
            if (!Patcher.isEnabled_Equip.Value)
            {
                return;
            }

            if (equipSlot != OcEquipSlot.WpMain)
            {
                return;
            }

            OcWpCategory category = __instance.getWpCategory(OcEquipSlot.WpMain);
            if (category != OcWpCategory.MagicStaff)
            {
                return;
            }

            var currentSize = item.ItemModel.transform.localScale;
            if (currentSize == Vector3.one)
            {
                item.ItemModel.transform.localScale = currentSize * 0.5f;
            }

            __instance.setEquip(item, equipSlot);
        }
    }

    [HarmonyPatch(typeof(OcPlEquipCtrl), "setEquip")]
    public class setEquipPatch
    {
        public static bool Prefix(OcItem item, OcEquipSlot equipSlot)
        {
            if (!Patcher.isEnabled_Equip.Value)
            {
                return true;
            }

            if (equipSlot != OcEquipSlot.WpMain && equipSlot != OcEquipSlot.WpSub)
            {
                return true;
            }

            OcWpCategory category = item.EquipPrefab.WpCategory;
            if (category != OcWpCategory.MagicStaff && category != OcWpCategory.RecallRod)
            {
                return true;
            }

            var currentSize = item.ItemModel.transform.localScale;
            if (currentSize == Vector3.one)
            {
                item.ItemModel.transform.localScale = currentSize * 0.5f;
            }

            return true;
        }
    }
}
