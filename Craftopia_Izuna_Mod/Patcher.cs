using System;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace Craftopia_Izuna_Mod
{
    [BepInPlugin(MOD_NAME, DISPLAY_NAME, VERSION)]
    public class Patcher : BaseUnityPlugin
    {
        public const string MOD_NAME = "muro1214.Craftpia_Izuna_Mod";
        public const string DISPLAY_NAME = "Craftpia_Izuna_Mod";
        public const string VERSION = "1.0.0";

        // Configurations : Enchant
        public static ConfigEntry<bool> isEnabled_Enchant;

        // Configurations : Skill
        public static ConfigEntry<bool> isEnabled_Skill;
        public static ConfigEntry<float> consumeManaRate;
        public static ConfigEntry<float> cooldownRate;

        // Configurations : Master
        public static ConfigEntry<bool> isEnabled_Master;

        // Configurations : Equip
        public static ConfigEntry<bool> isEnabled_Equip;

        // Configuration : Player
        public static ConfigEntry<bool> isEnabled_Player;
        public static ConfigEntry<long> experienceRate;
        public static ConfigEntry<int> skillPointRate;

        // Configuration : Item
        public static ConfigEntry<bool> isEnabled_Item;
        public static ConfigEntry<float> dropBonusRate;
        public static ConfigEntry<float> potionEffectiveRate;

        public void Awake()
        {
            isEnabled_Enchant = Config.Bind<bool>("CraftEnchant", "IsEnabled", true);

            isEnabled_Skill = Config.Bind<bool>("Skills", "IsEnabled", true);
            consumeManaRate = Config.Bind<float>("Skills", "ConsumeManaRate", 0.05f);
            cooldownRate = Config.Bind<float>("Skills", "CoolDownRate", 0.1f);

            isEnabled_Master = Config.Bind<bool>("Durability", "IsEnabled", true);

            isEnabled_Equip = Config.Bind<bool>("Equipment", "IsEnabled", true);

            isEnabled_Player = Config.Bind<bool>("Player", "IsEnabled", true);
            experienceRate = Config.Bind<long>("Player", "ExperienceRate", 2);
            skillPointRate = Config.Bind<int>("Player", "SkillPointRate", 2);

            isEnabled_Item = Config.Bind<bool>("Item", "IsEnabled", true);
            dropBonusRate = Config.Bind<float>("Item", "DropBonusRate", 7f);
            potionEffectiveRate = Config.Bind<float>("Item", "PotionEffectiveRate", 100f);

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
