# Workbench Hut

A Valheim mod that adds a **Workbench Hut** to the hammer — a small wooden shelter with a functional workbench inside, placed in one build action.

## Requirements

- [BepInEx Pack for Valheim](https://valheim.thunderstore.io/package/denikson/BepInExPack_Valheim/)
- [Jötunn](https://valheim.thunderstore.io/package/ValheimModding/Jotunn/)

## Installation

1. Install BepInEx and Jötunn if you have not already.
2. Copy the mod DLL from the build output:

   `D:\Kriss\Documents\Git\valheim-workbench-hut\WorkbenchHut\bin\Release\net48\WorkbenchHut.dll`

   …into your Valheim plugins folder (create the `WorkbenchHut` subfolder if needed):

   `C:\Program Files (x86)\Steam\steamapps\common\Valheim\BepInEx\plugins\WorkbenchHut\WorkbenchHut.dll`

3. Launch the game and enter a world.

## In-game usage

1. Equip the **hammer**.
2. Open the build menu.
3. Go to the **Crafting** tab.
4. Select **Workbench Hut** (32 Wood, 1 Stone, 2 Resin).
5. Place it — you get a complete hut with a workbench inside.

Interact with the workbench to craft as usual. The hut is one structure; removing it removes the whole thing.

## Building from source

1. Install Visual Studio 2022 with the .NET desktop workload.
2. Install BepInEx into your Valheim folder.
3. Copy `Environment.props.example` to `Environment.props` and set your Valheim install path.
4. Open `WorkbenchHut.sln` and build **Release**.

After a **Release** build, the DLL is at:

`D:\Kriss\Documents\Git\valheim-workbench-hut\WorkbenchHut\bin\Release\net48\WorkbenchHut.dll`

A **Debug** build copies it automatically to:

`C:\Program Files (x86)\Steam\steamapps\common\Valheim\BepInEx\plugins\WorkbenchHut\WorkbenchHut.dll`

## Multiplayer

All players need this mod installed. Server hosts should install it on the dedicated server as well.
