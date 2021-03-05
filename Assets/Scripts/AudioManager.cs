using System;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // GameController controller;
    public PlayerData data;

    public AudioMixerGroup mainMixer;
    public AudioSource[] audioSource;

    public Sound[] sounds;
    public Music[] musics;
    Sound s;
    Music m;
    int MusicIndex = 0;
    public static AudioManager instance;
    bool introPlayedOnce = false;

    private void Start()
    {
        audioSource = GetComponents<AudioSource>();

        data.personalities.Clear();
        data.currentState = EmotionalState.None;
        data.lastPosition = new Vector3(-20.66f, -10.47f, 0f);


        PlayMusic("mainintro");
        introPlayedOnce = false;
    }

    private void Awake()
    {

        //singleton deseni
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        //scene load olayında bu scriptin bulunduğu gameobject'i yoketmemeli.
        DontDestroyOnLoad(gameObject);

        //controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        //audiomanager içinde tanımladığım değişkenlerin atamasını yapıyorum. birden fazla sesim olduğu için her ses için tekrar edecek.
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.enabled = false;
        }
        foreach (Music m in musics)
        {
            m.source = gameObject.AddComponent<AudioSource>();
            m.source.clip = m.clip;

            m.source.volume = m.volume;
            m.source.pitch = m.pitch;
            m.source.loop = m.loop;
        }
    }
    void Update()
    {
        for (int i = 0; i < audioSource.Length; i++)
        {
            if (audioSource[i].outputAudioMixerGroup == null)
            {
                audioSource[i].outputAudioMixerGroup = mainMixer;
            }
        }


    }
    //spesifik olarak bir ses çalmak istediğimde kullanmak üzere hazırladığım method.
    public void Play(string name)
    {
        s = Array.Find(sounds, sound => sound.name == name);
        //ses varsa çalar, yoksa hata mesajı yazdırır.
        if (s == null)
        {
            Debug.Log("Sound " + name + " not found!");
            return;
        }

        foreach (var item in sounds)
        {
            if (item != s)
            {
                item.source.enabled = false;
            }
            else item.source.enabled = true;
        }

        s.source.Play();

    }
    public void PlayMusic(string name)
    {
        m = Array.Find(musics, music => music.name == name);
        //ses varsa çalar, yoksa hata mesajı yazdırır.
        if (m == null)
        {
            Debug.Log("Music " + name + " not found!");
            return;
        }
        foreach (var item in musics)
        {
            if (item != m)
            {
                item.source.enabled = false;
            }
            else item.source.enabled = true;
        }

        m.source.Play();
        //print(m.source.isPlaying);
    }

    //bu da spesifik bir sesi durdurmak için hazırladığım bir method.
    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound " + name + " not found!");
            return;
        }

        foreach (var item in sounds)
        {
            if (item != s)
            {
                s.source.enabled = false;
            }
            else s.source.enabled = true;
        }
        s.source.Stop();
    }
    public void StopPlayingMusic(string name)
    {
        Music m = Array.Find(musics, music => music.name == name);
        //ses varsa çalar, yoksa hata mesajı yazdırır.
        if (m == null)
        {
            Debug.Log("Music " + name + " not found!");
            return;
        }
        foreach (var item in musics)
        {
            if (item != m)
            {
                item.source.enabled = false;
            }
            else item.source.enabled = true;
        }
        m.source.Stop();
    }

    public void StopAllSound()
    {
        foreach (var item in sounds)
        {
            if (item.source.isPlaying)
            {
                item.source.Stop();
            }
        }
    }

    public void StopAllMusic()
    {
        foreach (var item in musics)
        {
            if (item.source.isPlaying)
            {
                item.source.Stop();
            }
        }
    }

    public void PauseAllMusic()
    {
        foreach (var item in musics)
        {
            if (item.source.isPlaying)
            {
                item.source.Pause();
            }
        }
    }

    public void StopMusicWithEffect()
    {
        int indexPlaying = 0;

        for (int i = 0; i < musics.Length; i++)
        {
            if (musics[i].name == GetPlayingMusic())
            {
                //print(musics[i].name + " is playing now.");
                indexPlaying = i;
            }
        }

        StartCoroutine(StopWithEffect(indexPlaying));
    }

    private string GetPlayingMusic()
    {
        string name = "";
        foreach (var item in musics)
        {
            if (item.source.isPlaying)
            {
                name = item.name;
            }

        }
        return name;
    }

    IEnumerator StopWithEffect(int index)
    {
        float duration = 2.5f;
        float timePassed = 0f;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            if (musics[index].source.pitch > 0)
            {
                musics[index].source.pitch -= Time.deltaTime;
            }
            else
            {
                musics[index].source.Stop();
                musics[index].source.pitch = 1;
            }

            yield return null;
        }
    }
    public void StopWithFadeOut()
    {
        int indexPlaying = 0;

        for (int i = 0; i < musics.Length; i++)
        {
            if (musics[i].name == GetPlayingMusic())
            {
                //print(musics[i].name + " is playing now.");
                indexPlaying = i;
            }
        }

        StartCoroutine(StopMusicFadeOut(indexPlaying));
    }

    IEnumerator StopMusicFadeOut(int index)
    {
        float duration = 2.5f;
        float timePassed = 0f;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            if (musics[index].source.volume > 0)
            {
                musics[index].source.volume -= Time.deltaTime;
            }
            else
            {
                musics[index].source.Stop();
                musics[index].source.volume = 1;
            }

            yield return null;
        }

        PlayMusic(data.currentState.ToString());
    }
    IEnumerator _ContinueWithEffect(int index)
    {
        float duration = 0.6f;
        float timePassed = 0f;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            if (musics[index].source.pitch < 1)
            {
                musics[index].source.pitch += Time.deltaTime * 0.5f;
            }
            yield return null;
        }

        musics[index].source.pitch = 1;
    }

    IEnumerator _PauseWithEffect(int index)
    {
        float duration = 0.6f;
        float timePassed = 0f;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            if (musics[index].source.pitch > 0.6)
            {
                musics[index].source.pitch -= Time.deltaTime * 0.5f;
            }
            yield return null;
        }
    }
    public void ContinueWithEffect(int index)
    {
        StartCoroutine(_ContinueWithEffect(index));
    }

    public void PauseWithEffect(int index)
    {
        StartCoroutine(_PauseWithEffect(index));
    }

    IEnumerator _StartWithEffect(int index)
    {
        float duration = 1f;
        float timePassed = 0f;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            if (musics[index].source.pitch < 1)
            {
                musics[index].source.pitch += Time.deltaTime * 0.2f;
            }
            yield return null;
        }
        musics[index].source.pitch = 1;
    }
    public void StartWithEffect(int index)
    {
        StartCoroutine(_StartWithEffect(index));
    }
    // public void PlayRandomMusic()
    // {
    //     StopAllMusic();
    //     int random = UnityEngine.Random.Range(0, instance.musics.Length);
    //     instance.PlayMusic(instance.musics[random].name);
    //     MusicIndex = random;
    // }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.onInteractionComplete, OnSceneChange);
    }
    private void OnDisable()
    {
        EventManager.RemoveHandler(GameEvent.onInteractionComplete, OnSceneChange);
    }
    void OnSceneChange()
    {
        StopWithFadeOut();
    }

}
