using BepInEx;
using Jotunn.Entities;
using Jotunn.Managers;
using Jotunn.Utils;

namespace WorkbenchHut
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInDependency(Jotunn.Main.ModGuid)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.Minor)]
    public class WorkbenchHutPlugin : BaseUnityPlugin
    {
        public const string PluginGuid = "kriss.workbenchhut";
        public const string PluginName = "Workbench Hut";
        public const string PluginVersion = "1.0.0";

        internal const string HutCategory = "Workbench Hut";

        public static CustomLocalization Localization;

        private void Awake()
        {
            Localization = LocalizationManager.Instance.GetLocalization();
            AddLocalizations();

            PrefabManager.OnVanillaPrefabsAvailable += RegisterHutPieces;
            Logger.LogInfo($"{PluginName} v{PluginVersion} loaded");
        }

        private static void AddLocalizations()
        {
            Localization.AddTranslation("English", new System.Collections.Generic.Dictionary<string, string>
            {
                { "jotunn_cat_workbench hut", "Workbench Hut" },

                { "piece_workbench_hut", "Workbench Hut" },
                { "piece_workbench_hut_description", "A small wooden hut with walls, roof, and a workbench inside. Place it in one go." },

                { "piece_workbench_hut_floor", "Hut Floor" },
                { "piece_workbench_hut_floor_description", "A wooden floor tile for your workbench hut." },

                { "piece_workbench_hut_wall", "Hut Wall" },
                { "piece_workbench_hut_wall_description", "A sturdy wall panel for your workbench hut." },

                { "piece_workbench_hut_roof", "Hut Roof" },
                { "piece_workbench_hut_roof_description", "A sloped roof section for your workbench hut." },

                { "piece_workbench_hut_roof_peak", "Hut Roof Peak" },
                { "piece_workbench_hut_roof_peak_description", "A roof cap for the top of your workbench hut." },

                { "piece_workbench_hut_door", "Hut Door" },
                { "piece_workbench_hut_door_description", "A wooden door for your workbench hut." },

                { "piece_workbench_hut_workbench", "Hut Workbench" },
                { "piece_workbench_hut_workbench_description", "A crafting workbench to place inside your hut." },
            });
        }

        private static void RegisterHutPieces()
        {
            CompleteHut.Register();
            HutPieces.RegisterKitPieces();
            PrefabManager.OnVanillaPrefabsAvailable -= RegisterHutPieces;
        }
    }
}
