using HarmonyLib;
using UnityEngine;

namespace HSVLayer.Patches
{
	[HarmonyPatch(typeof(EffectPoolsManualInstaller), nameof(EffectPoolsManualInstaller.ManualInstallBindings))]
	static class FlyingScoreEffectPatch
	{
		static void Prefix(FlyingScoreEffect ____flyingScoreEffectPrefab)
		{
			if(Plugin.flyingScoreEffectPrefab == null) Plugin.flyingScoreEffectPrefab = ____flyingScoreEffectPrefab;
            var hsv = Plugin.flyingScoreEffectPrefab.gameObject;
            hsv.layer = (int)Settings.Instance.Layer;
            foreach (Transform t in hsv.GetComponentsInChildren<Transform>())
            {
                t.gameObject.layer = (int)Settings.Instance.Layer;
            }
        }
	}
}
