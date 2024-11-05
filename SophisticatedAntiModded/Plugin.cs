using BepInEx;
using UnityEngine;
using Newtilla;

namespace SophisticatedAntiModded
{
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;

		void Start()
		{
			inRoom = false;
		}

		void OnEnable()
		{
			HarmonyPatches.ApplyHarmonyPatches();
		}

		void OnDisable()
		{
			HarmonyPatches.RemoveHarmonyPatches();
		}
		void Update()
		{
			if(inRoom)
			{
				Application.Quit();
			}
		}
		public void OnModdedJoin(string gamemode)
		{
			inRoom = true;
		}
	}
}
