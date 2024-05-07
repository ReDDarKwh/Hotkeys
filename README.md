# [Hotkeys 1.5](https://steamcommunity.com/sharedfiles/filedetails/?id=3241798504)</p>

**All credits to the original authors and maintainers, this is fork to update to 1.5. I may or may not fix bugs, depending on whether they annoy me or not.  The repositories for the previous versions can be found here:**

* [Original Source](https://github.com/AzeTheGreat/Hotkeys)
* [1.3 Source](https://github.com/vvanouytsel/Hotkeys)
* [1.4 Source](https://github.com/basicsmods/Hotkeys)

## Original description

Tired of moving your mouse all over the screen while your other hand sits idly by? Hotkeys fixes that, making UI navigation much faster (and sometimes completely skippable)!

This mod adds fully user configurable keybindings for a variety of purposes.

### Currently Implemented
* Multi-Keybindings: Bind multiple keys to a single item, allowing things like "Ctrl + X" to go straight to deconstructing.
* Architect Hotkeys: Open any subtab in the architect menu with a single keypress.
* Command Hotkeys: Set any command in the bottom left to a hotkey. Using a Direct Hotkey to go from the world to any designator, or a Gizmo Hotkey to override the default binding provided by the "misc" keys.
* Shift-Keybinding: Bind shift to any key you want. (Workaround for a Unity issue that prevents shift being detected in the vanilla binding menu.)


### Configuration
1. Portions of the mod can be enabled/disabled in the mod settings menu.
2. An "Assign Gizmos" key is generated. This can be assigned like any other keybinding - I recommend Alt+Shift+Ctrl.
3. In game, while holding the Assign Gizmos key, right click on any Command (such as Forbid in the Orders menu).
4. Changing or removing keys is also done by holding the Assign Gizmos key and right clicking on the relevant Command.
5. The default behavior is sufficient for 90% of cases. If keys overlap and you want to edit them, the "key Specificity" can be edited, which is explained in game.


#### Compatibility
* Hotkeys can be added or removed at any time. Nothing should ever break a save file.
* At worst, an error should pop up - if this occurs please let me know so I can fix it.
* Errors will likely be thrown if hotkeys are set for nonstandard designators implemented by mods. If that happens...don't do it. This won't break anything, it will just throw an error and not behave as expected. So far I've only seen this with Designator Shapes.
* Architect Hotkeys do not work if Architect Icons is installed, this is because Architect Icons rewrites the entire Architect Window instead of just modifying it.