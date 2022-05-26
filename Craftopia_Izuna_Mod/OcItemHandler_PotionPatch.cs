using HarmonyLib;
using Oc;
using Oc.Item;
using System.Collections.Generic;

namespace Craftopia_Izuna_Mod
{
    [HarmonyPatch(typeof(OcItemHandler_Potion), "TryUse")]
    public class TryUsePatch
    {
        public static void Postfix(OcItemStack itemStack)
        {
            if (!Patcher.isEnabled_Item.Value)
            {
                return;
            }

            List<short> potionList = new List<short>
            {
                5546, 5547, 5548, 5550
            };

            if (!potionList.Contains(itemStack.item.Id))
            {
                return;
            }

            float num12 = itemStack.item.data.BuffResistFireLv;
            float num13 = itemStack.item.data.BuffResistColdLv;
            float num14 = itemStack.item.data.BuffResistPoisonLv;
            float num15 = itemStack.item.data.BuffResistHellFireLv;

            float effectiveTime = itemStack.item.EffectiveTime * Patcher.potionEffectiveRate.Value;

            OcPlMaster.Inst.PlStatusCtrl.TemporaryExtend_ResistFire.UpdateExtend(num12, effectiveTime);
            OcPlMaster.Inst.PlStatusCtrl.TemporaryExtend_ResistCold.UpdateExtend(num13, effectiveTime);
            OcPlMaster.Inst.PlStatusCtrl.TemporaryExtend_ResistPoison.UpdateExtend(num14, effectiveTime);
            OcPlMaster.Inst.PlStatusCtrl.TemporaryExtend_ResistHellFire.UpdateExtend(num15, effectiveTime);
        }
    }
}
