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
                Category = PieceCategories.Crafting,
            };

            config.AddRequirement("Wood", 32, true);
            config.AddRequirement("Stone", 1, true);
            config.AddRequirement("Resin", 2, true);

            var hut = new CustomPiece(PieceName, "DevHouseStart", config);
            PrepareHousePrefab(hut.PiecePrefab);
            PieceManager.Instance.AddPiece(hut);
        }

        private static void PrepareHousePrefab(GameObject root)
        {
            // DevHouseStart is a complete vanilla starter shack (floor, walls, roof, workbench).
            // Remove world-only components that break player building.
            StripComponentsByTypeName(root, "Location", "TerrainModifier", "MusicLocation");

            // Optional extras in the dev house — keep only the shelter + workbench.
            RemoveChildIfNameContains(root, "bed");
            RemoveChildIfNameContains(root, "cooking");
            RemoveChildIfNameContains(root, "firepit");
            RemoveChildIfNameContains(root, "campfire");
            RemoveChildIfNameContains(root, "hearth");
        }

        private static void StripComponentsByTypeName(GameObject go, params string[] typeNames)
        {
            foreach (var component in go.GetComponentsInChildren<Component>(true))
            {
                if (component == null)
                {
                    continue;
                }

                foreach (var typeName in typeNames)
                {
                    if (component.GetType().Name == typeName)
                    {
                        Object.Destroy(component);
                        break;
                    }
                }
            }
        }

        private static void RemoveChildIfNameContains(GameObject root, string namePart)
        {
            foreach (var transform in root.GetComponentsInChildren<Transform>(true))
            {
                if (transform == root.transform)
                {
                    continue;
                }

                if (transform.name.ToLowerInvariant().Contains(namePart))
                {
                    Object.Destroy(transform.gameObject);
                }
            }
        }
    }
}
