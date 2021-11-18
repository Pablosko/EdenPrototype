using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioController _audioInstance;

    private AudioSource _audioFx;
    private AudioSource _audioMusic;

    private AudioClip[] _arrayFx;
    private AudioClip[] _arrayMusic;

    public static AudioController InstanceAudio
    {
        get
        {
            if(_audioInstance == null)
            {
                GameObject go = new GameObject("Audio Manager");
                go.AddComponent<AudioController>();
                DontDestroyOnLoad(go);
            }
            return _audioInstance;
        }
    }

    private void Awake()
    {
        _audioFx = gameObject.AddComponent<AudioSource>();
        _audioMusic = gameObject.AddComponent<AudioSource>();
        _audioInstance = this;
    }

    public void LoadAllFx()
    {
        _arrayMusic = Resources.LoadAll<AudioClip>(Constants.MUSICDIRECTORIES[0]);
        _arrayFx = Resources.LoadAll<AudioClip>(Constants.MUSICDIRECTORIES[1]);
    }

    public void PlayFx(Enums.Effects fx)
    {
        _audioFx.Stop();
        _audioFx.PlayOneShot(_arrayFx[(int)fx]);
    }

    public void PlayMusic(Enums.Music music)
    {
        _audioMusic.Stop();
        _audioMusic.PlayOneShot(_arrayMusic[(int)music]);
    }

    //Cleaning variable
    private void OnDestroy()
    {
        if (_audioInstance == this)
        {
            _audioInstance = null;
        }
    }
}
