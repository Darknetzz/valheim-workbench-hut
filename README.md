# Workbench Hut

A Valheim mod that adds a **Workbench Hut** to the hammer — place a complete small wooden shelter (walls, roof, and workbench) in a single build action. Individual hut pieces are also available if you prefer to build it yourself.

## Requirements

- [BepInEx Pack for Valheim](https://valheim.thunderstore.io/package/denikson/BepInExPack_Valheim/)
- [Jötunn](https://valheim.thunderstore.io/package/ValheimModding/Jotunn/)

## Installation

1. Install BepInEx and Jötunn if you have not already.
2. Copy `WorkbenchHut.dll` into `BepInEx/plugins/`.
3. Launch the game and enter a world.

## In-game usage

Open the hammer and select the **Workbench Hut** category.

### Workbench Hut (single piece)

Place **Workbench Hut** once to spawn a 4×4 m shelter with three walls, a roof, an open front, and a **fully functional workbench** inside.

| Materials |
|-----------|
| 32 Wood, 1 Stone, 2 Resin |

Interact with the workbench inside to craft as usual. The hut is one combined structure — removing it removes the whole thing.

### Individual pieces (optional)

You can also build a hut piece by piece:

| Piece | Materials |
|-------|-----------|
| Hut Floor | 2 Wood |
| Hut Wall | 2 Wood |
| Hut Roof | 2 Wood |
| Hut Roof Peak | 2 Wood |
| Hut Door | 4 Wood, 2 Resin |
| Hut Workbench | 2 Wood, 1 Stone |

## Building from source

1. Install Visual Studio 2022 with the .NET desktop workload.
2. Install BepInEx into your Valheim folder.
3. Copy `Environment.props.example` to `Environment.props` and set your Valheim install path.
4. Open `WorkbenchHut.sln` and build **Release**.

The DLL is copied to `BepInEx/plugins/` automatically on build (Windows).

## Multiplayer

All players need this mod installed. Server hosts should install it on the dedicated server as well.
