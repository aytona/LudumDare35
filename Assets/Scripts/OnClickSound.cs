using UnityEngine;

namespace Aytona.Effect
{
    public class OnClickSound : MonoBehaviour
    {
        public GameObject audioObj;
        public AudioClip clip;

        public void PlayClip()
        {
            AudioSource audio = audioObj.GetComponent<AudioSource>();
            audio.clip = clip;
            audio.Play();
        }
    }
}