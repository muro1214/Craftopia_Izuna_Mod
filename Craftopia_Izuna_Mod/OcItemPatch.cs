using HarmonyLib;
using Oc.Item;

namespace Craftopia_Izuna_Mod
{
    [HarmonyPatch(typeof(OcItem), "SetCooldownForSkill")]
    public class SetCooldownForSkillPatch
    {
        public static bool Prefix(ref float CDDuration)
        {
            if (!Patcher.isEnabled_Skill.Value)
            {
                return true;
            }

            CDDuration *= Patcher.cooldownRate.Value;

            return true;
        }
    }
}
