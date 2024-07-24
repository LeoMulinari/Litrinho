using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundController : MonoBehaviour
{



    public AudioSource musicSource;
    public AudioClip menuMusic;
    public AudioClip levelMusic;
    public AudioClip levelMusic2;
    public AudioClip levelMusic3;


    public AudioSource fxGame;
    public AudioClip itemColetado;
    public AudioClip jump;
    public AudioClip hit;
    public AudioClip confirm;
    public AudioClip cancel;
    public AudioClip select;

    public static SoundController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        //  PlayMusic(menuMusic);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level1")
        {
            PlayMusic(levelMusic);
        }
        else if (scene.name == "Level2")
        {
            PlayMusic(levelMusic2);
        }
        else if (scene.name == "Level3")
        {
            PlayMusic(levelMusic3);
        }
        else
        {
            PlayMusic(menuMusic);
        }
    }





    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == clip)
        {
            return; // If the same music is already playing, do nothing
        }

        musicSource.clip = clip;
        musicSource.Play();
    }
}
