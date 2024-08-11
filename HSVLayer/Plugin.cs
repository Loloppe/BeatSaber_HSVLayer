﻿using BeatSaberMarkupLanguage.GameplaySetup;
using HarmonyLib;
using IPA;
using IPA.Config.Stores;
using System.Reflection;
using IPALogger = IPA.Logging.Logger;

namespace HSVLayer
{
	[Plugin(RuntimeOptions.DynamicInit)]
	public class Plugin
	{
		internal static Plugin Instance;
		internal static IPALogger Log;
		internal static Harmony harmony;
        internal static FlyingScoreEffect flyingScoreEffectPrefab = null;

        [Init]
		public Plugin(IPALogger logger, IPA.Config.Config conf)
		{
			Instance = this;
			Log = logger;
            Settings.Instance = conf.Generated<Settings>();
            harmony = new Harmony("Loloppe.BeatSaber.HSVLayer");
		}

		[OnEnable]
		public void OnEnable()
		{
			harmony.PatchAll(Assembly.GetExecutingAssembly());
            GameplaySetup.instance.AddTab("HSVLayer", "HSVLayer.UI.settings.bsml", Settings.Instance, MenuType.All);
        }

		[OnDisable]
		public void OnDisable()
		{
			harmony.UnpatchSelf();
            GameplaySetup.instance.RemoveTab("HSVLayer");
        }
	}
}
