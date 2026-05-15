using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;

namespace ShowRaftCenterNG;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin {
	internal static new ManualLogSource Logger;
	private ConfigEntry<string> keybind;

	private void Awake() {
		// Plugin startup logic
		Logger = base.Logger;
		Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

		keybind = Config.Bind("General", "Keybind", "=", "The keybind used to show the center");
		Logger.LogInfo($"Using '{keybind.Value}' for the keybind");
	}
}
