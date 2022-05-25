using HarmonyLib;
using Oc;

namespace Craftopia_Izuna_Mod
{
    [HarmonyPatch(typeof(OcPlLevelCtrl), "AddExp")]
    public class AddExpPatch
    {
        public static bool Prefix(ref long value)
        {
            if (!Patcher.isEnabled_Player.Value)
            {
                return true;
            }

            value *= Patcher.experienceRate.Value;

            return true;
        }
    }
}
