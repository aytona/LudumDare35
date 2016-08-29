using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Aytona.Sound
{
    public class SoundManager : Global.Singleton<SoundManager>
    {
        public List<AudioSource> SFXSources;

        void Start()
        {
            foreach(AudioSource source in gameObject.GetComponentsInChildren<AudioSource>(true))
            {
                SFXSources.Add(source);
            }
        }

        public void UpdateAudioVolume(Slider slider)
        {
            foreach(AudioSource source in SFXSources)
            {
                source.volume = slider.value;
            }
        }
    }
}