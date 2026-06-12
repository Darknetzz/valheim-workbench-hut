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

            config.AddRequirement("Wood", 14, true);
            config.AddRequirement("Stone", 1, true);

            var hut = new CustomPiece(PieceName, "piece_workbench", config);
            AssembleLittleHut(hut.PiecePrefab);
            PieceManager.Instance.AddPiece(hut);
        }

        private static void AssembleLittleHut(GameObject root)
        {
            var structure = new GameObject("hut_structure");
            structure.transform.SetParent(root.transform, false);
            structure.transform.localPosition = new Vector3(0f, 0f, -0.25f);
            structure.transform.localRotation = Quaternion.identity;

            // Open-front 2x2 m shed: three walls + peaked roof, no floor.
            AddVisual(structure, "woodwall", "wall_back", new Vector3(0f, 0f, -1f), Quaternion.identity);
            AddVisual(structure, "woodwall", "wall_left", new Vector3(-1f, 0f, 0f), Quaternion.Euler(0f, 90f, 0f));
            AddVisual(structure, "woodwall", "wall_right", new Vector3(1f, 0f, 0f), Quaternion.Euler(0f, 270f, 0f));

            AddVisual(structure, "wood_roof_45", "roof_w", new Vector3(-1f, 2f, 0f), Quaternion.Euler(0f, 270f, 0f));
            AddVisual(structure, "wood_roof_45", "roof_e", new Vector3(1f, 2f, 0f), Quaternion.Euler(0f, 90f, 0f));
            AddVisual(structure, "wood_roof_top_45", "roof_peak", new Vector3(0f, 2.75f, 0f), Quaternion.identity);
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
                if (typeName is "Piece" or "WearNTear" or "ZNetView" or "ZSyncTransform" or "CraftingStation")
                {
                    Object.Destroy(component);
                }
            }
        }
    }
}
