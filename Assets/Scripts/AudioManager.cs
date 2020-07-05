using UnityEngine;
using System;
using UnityEngine.Audio;


public enum SoundType { music, sound}
public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    public float masterVolume = 0.5f;
    public float musicVolume = 0.5f;
    public float soundVolume = 0.5f;

    [System.Serializable]
    public class Sound
    {
        public SoundType type;
        public string name;
        public AudioClip clip;
        [HideInInspector] public AudioSource source;

        public bool loop;

        [Range(0f, 1f)]
        public float volume;
        [Range(0.1f, 3f)]
        public float pitch;
    }

    public Sound[] sounds;

    private void Play(string soundName)
    {
        Sound sound = Array.Find(sounds, s => s.name == soundName);
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }
        sound.source.Play();
    }

    private void Stop(string soundName)
    {
        Sound sound = Array.Find(sounds, s => s.name == soundName);
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found.");
            return;
        }

        //sound.source.volume = sound.volume * (1f + UnityEngine.Random.Range(-sound.volumeVariance / 2f, sound.volumeVariance / 2f));
        //sound.source.pitch = sound.pitch * (1f + UnityEngine.Random.Range(-sound.pitchVariance / 2f, sound.pitchVariance / 2f));

        sound.source.Stop();
    }

    private void Awake()
    {

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        EventSystemGame.current.onPlaySound += Play;
        EventSystemGame.current.onStopSound += Stop;

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();

            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume * masterVolume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;

        }
    }

    public void ChangeMasterVolume(float newVolume)
    {
        masterVolume = newVolume;

        foreach (Sound sound in sounds)
        {
            sound.source.volume = sound.volume * masterVolume;
        }
    }

    public void ChangeMusicVolume(float newVolume)
    {
        musicVolume = newVolume;

        foreach (Sound sound in sounds)
        {
            if (sound.type == SoundType.music)
                sound.source.volume = sound.volume * musicVolume;
        }
    }

    public void ChangeSoundVolume(float newVolume)
    {
        soundVolume = newVolume;

        foreach (Sound sound in sounds)
        {
            if (sound.type == SoundType.sound)
                sound.source.volume = sound.volume * soundVolume;
        }
    }

    public void BtnClickSound() { Play("Click"); } //called by button in menus

    private void OnDestroy()
    {
        EventSystemGame.current.onPlaySound -= Play;
        EventSystemGame.current.onStopSound -= Stop;
    }
}
