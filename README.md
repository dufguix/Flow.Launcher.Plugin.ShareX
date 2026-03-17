# ShareX Plugin for Flow Launcher

## Plugin behavior
All commands are based on ShareX HotkeyType enum from [ShareX/Enums.cs](https://github.com/ShareX/ShareX/blob/master/ShareX/Enums.cs).

The plugin now includes a settings panel in Flow Launcher:
- Configure ShareX installation path (defaults to `C:\Program Files\ShareX\`).
- Enable/disable auto close (`-autoclose`) after successful tasks.

When executing commands, the plugin starts ShareX with `-silent` and optionally `-autoclose`.

## Manual installation
1. Open the solution with Visual Studio 2026.
2. Build in Release.
3. Copy the content of `.\bin\Release\`.
4. Paste into `C:\Users\<username>\AppData\Roaming\FlowLauncher\Plugins\ShareX`.
