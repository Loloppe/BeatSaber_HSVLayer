using HarmonyLib;
using IPA;
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

		[Init]
		public Plugin(IPALogger logger)
		{
			Instance = this;
			Log = logger;
			harmony = new Harmony("Loloppe.BeatSaber.HSVLayer");
		}

		[OnEnable]
		public void OnEnable()
		{
			harmony.PatchAll(Assembly.GetExecutingAssembly());
			Log.Warn("patched");
		}

		[OnDisable]
		public void OnDisable()
		{
			harmony.UnpatchSelf();
		}
	}
}
