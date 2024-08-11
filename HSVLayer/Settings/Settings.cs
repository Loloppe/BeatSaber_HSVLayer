using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using BeatSaberMarkupLanguage.Attributes;
using CameraUtils.Core;
using IPA.Config.Stores;
using UnityEngine;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace HSVLayer
{
    internal class Settings
    {
        public static Settings Instance;
        [UIValue("layer")]
        public virtual VisibilityLayer Layer { get; set; } = VisibilityLayer.UI;
        [UIValue("layers")]
        public List<object> Layers => Options();

        private List<object> Options()
        {
            List<object> list = new List<object>();
            foreach (var item in Enum.GetValues(typeof(VisibilityLayer)))
            {
                list.Add(item);
            }
            return list;
        }

        /// <summary>
        /// This is called whenever BSIPA reads the config from disk (including when file changes are detected).
        /// </summary>
        public virtual void OnReload()
        {
            // Do stuff after config is read from disk.
        }

        /// <summary>
        /// Call this to force BSIPA to update the config file. This is also called by BSIPA if it detects the file was modified.
        /// </summary>
        public virtual void Changed()
        {
            // Do stuff when the config is changed.
            if (Plugin.flyingScoreEffectPrefab != null)
            {
                var hsv = Plugin.flyingScoreEffectPrefab.gameObject;
                hsv.layer = (int)Layer;
                foreach (Transform t in hsv.GetComponentsInChildren<Transform>())
                {
                    t.gameObject.layer = (int)Layer;
                }
            }
        }

        /// <summary>
        /// Call this to have BSIPA copy the values from <paramref name="other"/> into this config.
        /// </summary>
        public virtual void CopyFrom(Settings other)
        {
            // This instance's members populated from other
        }
    }
}