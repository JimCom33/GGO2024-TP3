using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace benjohnson
{
    public class SoundManager : Singleton<SoundManager>
    {
        [SerializeField] AudioSource effectsSource;
        [SerializeField] AudioSource musicSource;

        [SerializeField] List<AudioProfile> clips;
        [SerializeField] List<AudioProfile> music;

        private bool isMuted = false;

        private void Start()
        {
            LoadSoundSettings();
        }

        private void Update()
        {
            if (!musicSource.isPlaying)
                PlayMusic(0);
        }

        public void PlaySound(string id)
        {
            if (isMuted) return;
            for (int i = 0; i < clips.Count; i++)
            {
                if (clips[i].name == id)
                    PlaySound(i);
            }
        }

        public void PlaySound(int i)
        {
            if (isMuted) return;
            effectsSource.PlayOneShot(clips[i].Clip(), clips[i].volume);
        }

        public void PlayMusic(int i)
        {
            if (isMuted) return;
            musicSource.PlayOneShot(music[i].Clip(), music[i].volume);
        }

        public void ToggleSound()
        {
            isMuted = !isMuted;
            PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
            UpdateAudioSources();
        }

        private void LoadSoundSettings()
        {
            isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
            UpdateAudioSources();
        }

        private void UpdateAudioSources()
        {
            musicSource.mute = isMuted;
            effectsSource.mute = isMuted;
        }

        public bool IsMuted()
        {
            return isMuted;
        }
    }

    [System.Serializable]
    public class AudioProfile
    {
        public string name;
        public AudioClip[] clips;
        public AudioClip Clip()
        {
            return clips[Random.Range(0, clips.Length)];
        }
        [Range(0, 1)] public float volume = 0.5f;
    }
}
