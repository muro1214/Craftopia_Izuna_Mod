using HarmonyLib;
using Oc;

namespace Craftopia_Izuna_Mod
{
    [HarmonyPatch(typeof(OcPlSkillCtrl), "calcConsumeManaRate")]
    public class OcPlSkillCtrlPatch
    {
        public static void Postfix(ref float __result)
        {
            if (!Patcher.isEnabled_Skill.Value)
            {
                return;
            }

            __result = Patcher.consumeManaRate.Value;
        }
    }

    [HarmonyPatch(typeof(OcPlSkillCtrl), "AddSkillPoint")]
    public class AddSkillPointPatch
    {
        public static bool Prefix(ref int value)
        {
            if (!Patcher.isEnabled_Player.Value)
            {
                return true;
            }

            value *= Patcher.skillPointRate.Value;

            return true;
        }
    }
}
