using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;

namespace WorkbenchHut
{
    internal static class HutPieces
    {
        internal static void RegisterKitPieces()
        {
            AddClonedPiece(
                "piece_workbench_hut_floor",
                "wood_floor_1x1",
                "$piece_workbench_hut_floor",
                "$piece_workbench_hut_floor_description",
                ("Wood", 2));

            AddClonedPiece(
                "piece_workbench_hut_wall",
                "woodwall",
                "$piece_workbench_hut_wall",
                "$piece_workbench_hut_wall_description",
                ("Wood", 2));

            AddClonedPiece(
                "piece_workbench_hut_roof",
                "wood_roof_45",
                "$piece_workbench_hut_roof",
                "$piece_workbench_hut_roof_description",
                ("Wood", 2));

            AddClonedPiece(
                "piece_workbench_hut_roof_peak",
                "wood_roof_top_45",
                "$piece_workbench_hut_roof_peak",
                "$piece_workbench_hut_roof_peak_description",
                ("Wood", 2));

            AddClonedPiece(
                "piece_workbench_hut_door",
                "wood_door",
                "$piece_workbench_hut_door",
                "$piece_workbench_hut_door_description",
                ("Wood", 4), ("Resin", 2));

            AddClonedPiece(
                "piece_workbench_hut_workbench",
                "piece_workbench",
                "$piece_workbench_hut_workbench",
                "$piece_workbench_hut_workbench_description",
                ("Wood", 2), ("Stone", 1));
        }

        private static void AddClonedPiece(
            string pieceName,
            string vanillaPrefab,
            string displayName,
            string description,
            params (string item, int amount)[] requirements)
        {
            var config = new PieceConfig
            {
                Name = displayName,
                Description = description,
                PieceTable = PieceTables.Hammer,
                Category = WorkbenchHutPlugin.HutCategory,
            };

            foreach (var (item, amount) in requirements)
            {
                config.AddRequirement(item, amount, true);
            }

            PieceManager.Instance.AddPiece(new CustomPiece(pieceName, vanillaPrefab, config));
        }
    }
}
