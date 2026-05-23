# ShowRaftCenterNG

A mod for [Raft][raft] that allows you to find the center of your raft.

It is based on the [BepInEx][bepinex] modding framework, which you'll need to 
[have installed][bepinst]. If you're on Linux, still choose the Windows version, since
the game runs through Proton, and follow the [Wine configuration][bepwine] guide.

Parts of the code are adapted from the original [ShowRaftCenter][ogmod] mod, which
does the same thing. You may want [to use it][useog] instead, in which case don't
forget to set `HideManagerGameObject = true` in your `BepInEx.cfg`. But if you
choose to use this plugin, the option is redundant.

The only reason for this mod to exist, is that I didn't figure out this
configuration option in time.

## Build

To build the project, run `dotnet build -c Release` with the `RAFT_DIR`
environment variable provided (e.g.
`RAFT_DIR=~/.local/share/Steam/steamapps/common/Raft dotnet build -c Release`).

[bepinex]: https://github.com/BepInEx/BepInEx
[bepinst]: https://docs.bepinex.dev/articles/user_guide/installation/index.html
[bepwine]: https://docs.bepinex.dev/articles/advanced/proton_wine.html
[ogmod]: https://github.com/aedenthorn/RaftMods
[useog]: https://www.nexusmods.com/raft/mods/43
[raft]: https://www.raft-game.com/

## Copyright

    ShowRaftCenterNG — A mod for Raft to show the center of the raft
    Copyright (C) 2026  Maksym Hazevych

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.

