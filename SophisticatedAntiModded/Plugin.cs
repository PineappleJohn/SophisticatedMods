using BepInEx;
using UnityEngine;
using Newtilla;
using Photon.Pun;

namespace SophisticatedAntiModded
{
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;
		bool enabledMod;

		void Start()
		{
			inRoom = false;

			Newtilla.Newtilla.OnJoinModded += OnModdedJoin;
			Newtilla.Newtilla.OnLeaveModded += OnModdedLeave;
		}

		void OnEnable()
		{
			HarmonyPatches.ApplyHarmonyPatches();
			enabledMod = true;
		}

		void OnDisable()
		{
			HarmonyPatches.RemoveHarmonyPatches();
			enabledMod = false;
		}
		void Update()
		{
			if (!inRoom && enabledMod)
			{
				PhotonNetwork.Disconnect();
			}
		}
		public void OnModdedJoin(string gamemode)
		{
			inRoom = true;
		}

		public void OnModdedLeave(string gamemode)
		{
			inRoom = false;
		}
	}
}
