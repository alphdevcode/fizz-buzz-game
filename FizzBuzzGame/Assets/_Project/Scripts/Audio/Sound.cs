using System;
using AlphDevCode.Managers;
using UnityEngine;

namespace AlphDevCode.Audio
{
    [Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;
        
        [Range(0f,1f)]
        public float volume = 0.7f;
        [Range(.1f,3f)]
        public float pitch = 1f;

        public bool loop;
    
        private AudioSource source;
    
        public void SetSource(AudioSource source)
        {
            this.source = source;
            this.source.clip = clip;
            this.source.volume = volume;
            this.source.pitch = pitch;
            this.source.loop = loop;
        }

        public void Play()
        {
            source.Play();
        }
    
        public void Pause()
        {
            source.Pause();
        }
    
        public void Stop()
        {
            source.Stop();
        }
    }
}