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
	internal static ConfigEntry<Color> colorOne;
	internal static ConfigEntry<Color> colorTwo;

	private void Awake() {
		Logger = base.Logger;
		Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

		keybind = Config.Bind("General", "Keybind", "=", "The keybind used to show the center");
		colorOne = Config.Bind<Color>("Options", "ColorOne", Color.white, "Color One");
		colorTwo = Config.Bind<Color>("Options", "ColorTwo", new Color(0.75f, 0.75f, 0.75f, 1),
									  "Color Two");

		Logger.LogDebug($"Using '{keybind.Value}' for the keybind");

		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		if (scene.name != "MainScene") {
			return;
		}

		var go = new GameObject("ShowRaftCenterNG");
		DontDestroyOnLoad(go);
		go.AddComponent<PluginBehaviour>();

		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
}

public class PluginBehaviour : MonoBehaviour {
	private static GameObject marker;

	private void Update() {
		if (Input.GetKeyDown(Plugin.keybind.Value)) {
			Plugin.Logger.LogDebug($"Detected '{Plugin.keybind.Value}' key press!");
			MarkerHandler();
		}

		if (marker != null) {
			UpdateMarkerColor();
		}
	}

	private void MarkerHandler() {
		if (marker == null) {
			Raft raft = ComponentManager<Raft>.Value;
			marker = CreateMarker();
			marker.transform.SetParent(raft.transform, false);
		} else {
			Destroy(marker);
			marker = null;
		}
	}

	private GameObject CreateMarker() {
		var marker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		marker.GetComponent<Collider>().enabled = false;
		marker.GetComponent<MeshRenderer>().material.color = Plugin.colorOne.Value;
		marker.transform.localScale = new Vector3(0.2f, 100, 0.2f);

		return marker;
	}

	private void UpdateMarkerColor() {
		if (Plugin.colorOne.Value != Plugin.colorTwo.Value) {
			marker.GetComponent<MeshRenderer>().material.color = Color.Lerp(
				Plugin.colorOne.Value, Plugin.colorTwo.Value, Mathf.PingPong(Time.time, 1));
			if (marker.GetComponent<MeshRenderer>().material.color == Plugin.colorTwo.Value) {
				marker.GetComponent<MeshRenderer>().material.color = Plugin.colorOne.Value;
			}
		}
	}
}
