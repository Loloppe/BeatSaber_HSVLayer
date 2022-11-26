using HarmonyLib;
using UnityEngine;

namespace HSVLayer.Patches
{
	[HarmonyPatch(typeof(EffectPoolsManualInstaller), nameof(EffectPoolsManualInstaller.ManualInstallBindings))]
	static class FlyingScoreEffectPatch
	{
		[HarmonyPriority(int.MinValue)]
		static void Prefix(FlyingScoreEffect ____flyingScoreEffectPrefab)
		{
			var hsv = ____flyingScoreEffectPrefab.gameObject;
			int layer = 8;
			hsv.layer = layer;
			foreach (Transform t in hsv.GetComponentsInChildren<Transform>())
			{
				t.gameObject.layer = layer;
			}
		}
	}
}
