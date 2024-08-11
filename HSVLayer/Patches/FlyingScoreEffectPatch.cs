using HarmonyLib;

namespace HSVLayer.Patches
{
	[HarmonyPatch(typeof(EffectPoolsManualInstaller), nameof(EffectPoolsManualInstaller.ManualInstallBindings))]
	static class FlyingScoreEffectPatch
	{
		static void Prefix(FlyingScoreEffect ____flyingScoreEffectPrefab)
		{
			if(Plugin.flyingScoreEffectPrefab == null) Plugin.flyingScoreEffectPrefab = ____flyingScoreEffectPrefab;
        }
	}
}
