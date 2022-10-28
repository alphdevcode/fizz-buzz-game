using System;
using AlphDevCode.Audio;
using UnityEngine;

namespace AlphDevCode.Managers
{
    public class AudioSystem : MonoBehaviour
    {
        public Sound[] sounds;

        public static AudioSystem instance;

        private void Awake()
        {
            if (instance == null) instance = this;
            else
            {
                Destroy(gameObject);
                return;
            }

            DontDestroyOnLoad(gameObject);

            foreach (var s in sounds)
            {
                GameObject soundObject = new GameObject("Sound_" + s.name);
                soundObject.transform.SetParent(this.transform);

                s.SetSource(soundObject.AddComponent<AudioSource>());

            }
        }

        private Sound FindSound(string soundName)
        {
            var sound = Array.Find(sounds, sound => sound.name == soundName);
            if (sound != null) return sound;
            Debug.LogWarning("Sound: " + soundName + " not found!");
            return null;
        }
        
        public void PlaySoundAtPoint(string soundName, Vector3 position)
        {
            var s = FindSound(soundName);
            AudioSource.PlayClipAtPoint(s.clip, position);
        }

        public void PlaySound(string soundName)
        {
            var s = FindSound(soundName);
            s.Play();
        }

        public void StopSound(string soundName)
        {
            var s = FindSound(soundName);
            s.Stop();
        }

        public void PauseSound(string soundName)
        {
            var s = FindSound(soundName);
            s.Pause();
        }
    }
}