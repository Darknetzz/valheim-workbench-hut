# Workbench Hut

A Valheim mod that adds a **Workbench Hut** building kit to the hammer. Build a small wooden shelter with walls, a roof, a door, and a functional workbench inside.

## Requirements

- [BepInEx Pack for Valheim](https://valheim.thunderstore.io/package/denikson/BepInExPack_Valheim/)
- [Jötunn](https://valheim.thunderstore.io/package/ValheimModding/Jotunn/)

## Installation

1. Install BepInEx and Jötunn if you have not already.
2. Copy `WorkbenchHut.dll` into `BepInEx/plugins/`.
3. Launch the game and enter a world.

## In-game usage

Open the hammer and select the **Workbench Hut** category. The kit includes:

| Piece | Materials |
|-------|-----------|
| Hut Floor | 2 Wood |
| Hut Wall | 2 Wood |
| Hut Roof | 2 Wood |
| Hut Roof Peak | 2 Wood |
| Hut Door | 4 Wood, 2 Resin |
| Hut Workbench | 2 Wood, 1 Stone |

### Suggested 2×2 hut layout

1. Place **4 Hut Floor** tiles in a 2×2 square.
2. Build **Hut Wall** pieces on three sides.
3. Add a **Hut Door** on the open side.
4. Cap the roof with **Hut Roof** sections and a **Hut Roof Peak** at the top.
5. Place the **Hut Workbench** inside — it works like a normal workbench for crafting.

## Building from source

1. Install Visual Studio 2022 with the .NET desktop workload.
2. Install BepInEx into your Valheim folder.
3. Copy `Environment.props.example` to `Environment.props` and set your Valheim install path.
4. Open `WorkbenchHut.sln` and build **Release**.

The DLL is copied to `BepInEx/plugins/` automatically on build (Windows).

## Multiplayer

All players need this mod installed. Server hosts should install it on the dedicated server as well.
