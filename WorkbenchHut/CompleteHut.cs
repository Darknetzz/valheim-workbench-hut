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

            // piece_workbench has the required Piece + CraftingStation components.
            var hut = new CustomPiece(PieceName, "piece_workbench", config);

            var houseVisual = PrefabManager.Instance.CreateClonedPrefab($"{PieceName}_visual", "DevHouseStart");
            PrepareHouseVisual(houseVisual);
            houseVisual.transform.SetParent(hut.PiecePrefab.transform, false);
            houseVisual.transform.localPosition = new Vector3(0f, 0f, 1.5f);
            houseVisual.transform.localRotation = Quaternion.identity;

            PieceManager.Instance.AddPiece(hut);
        }

        private static void PrepareHouseVisual(GameObject house)
        {
            StripComponentsByTypeName(
                house,
                "Location",
                "TerrainModifier",
                "MusicLocation",
                "Piece",
                "WearNTear",
                "ZNetView",
                "ZSyncTransform",
                "CraftingStation");

            // DevHouseStart includes its own workbench — remove it so the root workbench is used.
            RemoveChildIfNameContains(house, "piece_workbench");
            RemoveChildIfNameContains(house, "bed");
            RemoveChildIfNameContains(house, "cooking");
            RemoveChildIfNameContains(house, "firepit");
            RemoveChildIfNameContains(house, "campfire");
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
