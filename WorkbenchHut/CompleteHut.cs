using Jotunn.Configs;
using Jotunn.Entities;
using Jotunn.Managers;
using UnityEngine;

namespace WorkbenchHut
{
    internal static class CompleteHut
    {
        private const string PieceName = "piece_workbench_hut";

        internal static void Register()
        {
            var config = new PieceConfig
            {
                Name = "$piece_workbench_hut",
                Description = "$piece_workbench_hut_description",
                PieceTable = PieceTables.Hammer,
                Category = WorkbenchHutPlugin.HutCategory,
            };

            config.AddRequirement("Wood", 32, true);
            config.AddRequirement("Stone", 1, true);
            config.AddRequirement("Resin", 2, true);

            var hut = new CustomPiece(PieceName, "piece_workbench", config);
            AssembleHutVisuals(hut.PiecePrefab);
            PieceManager.Instance.AddPiece(hut);
        }

        private static void AssembleHutVisuals(GameObject root)
        {
            // 4x4m footprint (2x2 floor tiles), three walls, roof, open front. Workbench stays on the root.
            AddVisual(root, "wood_floor_1x1", "floor_sw", new Vector3(-1f, 0f, -1f), Quaternion.identity);
            AddVisual(root, "wood_floor_1x1", "floor_se", new Vector3(1f, 0f, -1f), Quaternion.identity);
            AddVisual(root, "wood_floor_1x1", "floor_nw", new Vector3(-1f, 0f, 1f), Quaternion.identity);
            AddVisual(root, "wood_floor_1x1", "floor_ne", new Vector3(1f, 0f, 1f), Quaternion.identity);

            AddVisual(root, "woodwall", "wall_back", new Vector3(0f, 0f, -2f), Quaternion.identity);
            AddVisual(root, "woodwall", "wall_left", new Vector3(-2f, 0f, 0f), Quaternion.Euler(0f, 90f, 0f));
            AddVisual(root, "woodwall", "wall_right", new Vector3(2f, 0f, 0f), Quaternion.Euler(0f, 270f, 0f));

            AddVisual(root, "wood_roof_45", "roof_w", new Vector3(-0.75f, 2f, 0f), Quaternion.Euler(0f, 90f, 0f));
            AddVisual(root, "wood_roof_45", "roof_e", new Vector3(0.75f, 2f, 0f), Quaternion.Euler(0f, 270f, 0f));
            AddVisual(root, "wood_roof_top_45", "roof_peak", new Vector3(0f, 2.75f, 0f), Quaternion.identity);
        }

        private static void AddVisual(
            GameObject parent,
            string sourcePrefab,
            string childName,
            Vector3 localPosition,
            Quaternion localRotation)
        {
            var visual = PrefabManager.Instance.CreateClonedPrefab($"{PieceName}_{childName}", sourcePrefab);
            StripBuildingComponents(visual);
            visual.name = childName;
            visual.transform.SetParent(parent.transform, false);
            visual.transform.localPosition = localPosition;
            visual.transform.localRotation = localRotation;
            visual.transform.localScale = Vector3.one;
        }

        private static void StripBuildingComponents(GameObject go)
        {
            foreach (var component in go.GetComponentsInChildren<Component>(true))
            {
                if (component == null)
                {
                    continue;
                }

                var typeName = component.GetType().Name;
                if (typeName is "Piece" or "WearNTear" or "ZNetView" or "ZSyncTransform")
                {
                    Object.Destroy(component);
                }
            }
        }
    }
}
