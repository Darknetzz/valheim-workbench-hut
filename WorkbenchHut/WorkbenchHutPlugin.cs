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
        public const string PluginVersion = "1.1.1";

        public static CustomLocalization Localization;

        private void Awake()
        {
            Localization = LocalizationManager.Instance.GetLocalization();
            AddLocalizations();

            PrefabManager.OnVanillaPrefabsAvailable += RegisterHutPiece;
            Logger.LogInfo($"{PluginName} v{PluginVersion} loaded");
        }

        private static void AddLocalizations()
        {
            Localization.AddTranslation("English", new System.Collections.Generic.Dictionary<string, string>
            {
                { "piece_workbench_hut", "Workbench Hut" },
                { "piece_workbench_hut_description", "A small wooden hut with a workbench inside." },
            });
        }

        private static void RegisterHutPiece()
        {
            CompleteHut.Register();
            PrefabManager.OnVanillaPrefabsAvailable -= RegisterHutPiece;
        }
    }
}
