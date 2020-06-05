using UnityEngine;
using System;
using UnityEngine.Audio;



public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class Sound
    {
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
        EventSystemGame.current.onPlaySound += Play;
        EventSystemGame.current.onStopSound += Stop;

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();

            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }
    private void Start()
    {
        //Play("Song");
    }

    public void BtnClickSound() { Play("Click"); }
}
