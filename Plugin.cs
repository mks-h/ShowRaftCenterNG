using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShowRaftCenterNG;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin {
	internal static new ManualLogSource Logger;
	internal static ConfigEntry<string> keybind;

	private void Awake() {
		Logger = base.Logger;
		Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

		keybind = Config.Bind("General", "Keybind", "=", "The keybind used to show the center");
		Logger.LogInfo($"Using '{keybind.Value}' for the keybind");

		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		Logger.LogInfo($"Scene loaded: {scene.name}");

		var go = new GameObject("ShowRaftCenterNG");
		DontDestroyOnLoad(go);
		go.AddComponent<PluginBehaviour>();

		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
}

public class PluginBehaviour : MonoBehaviour {
	private void Update() {
		if (Input.GetKeyDown(Plugin.keybind.Value)) {
			Plugin.Logger.LogInfo("Key pressed");
		}
	}
}
