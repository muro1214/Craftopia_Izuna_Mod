using HarmonyLib;
using Oc.Skills;

namespace Craftopia_Izuna_Mod
{
    [HarmonyPatch(typeof(OcSkillManager), "GameStartCheckSkillPoint")]
    public class GameStartCheckSkillPointPatch
    {
        public static bool Prefix()
        {
            if (!Patcher.isEnabled_Player.Value)
            {
                return true;
            }

            return false;
        }
    }
}
