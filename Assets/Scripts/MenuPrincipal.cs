using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    private SoundController soundController;
    public bool audioOn = true;
    public GameObject TelaInicio;
    public Button volumeButton;
    private bool canToggleVolume = true;

    public Sprite volumeOnSprite;
    public Sprite volumeOffSprite;
    private Image volumeButtonImage;

    void Start()
    {
        soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
        volumeButton.onClick.AddListener(VolumeGame);
        volumeButtonImage = volumeButton.GetComponent<Image>();

        audioOn = PlayerPrefs.GetInt("AudioOn", 1) == 1;
        AudioListener.volume = audioOn ? 1 : 0;
        volumeButtonImage.sprite = audioOn ? volumeOnSprite : volumeOffSprite;
    }

    public void Jogar()
    {
        soundController.fxGame.PlayOneShot(soundController.confirm);
        SceneManager.LoadScene("MenuLevel");
        Time.timeScale = 1;

    }

    public void VoltarMenu()
    {
        soundController.fxGame.PlayOneShot(soundController.cancel);
        SceneManager.LoadScene("MenuPrincipal");
        Time.timeScale = 1;

    }

    public void VolumeGame()
    {
        if (canToggleVolume)
        {
            audioOn = !audioOn;
            if (audioOn)
            {
                AudioListener.volume = 1;
                volumeButtonImage.sprite = volumeOnSprite;
            }
            else
            {
                AudioListener.volume = 0;
                volumeButtonImage.sprite = volumeOffSprite;
            }

            PlayerPrefs.SetInt("AudioOn", audioOn ? 1 : 0);

            StartCoroutine(DisableVolumeButtonTemporarily());
        }
    }

    private IEnumerator DisableVolumeButtonTemporarily()
    {
        canToggleVolume = false;
        volumeButton.interactable = false;
        yield return new WaitForSeconds(0.1f);  // Tempo para reativar o botão
        volumeButton.interactable = true;
        canToggleVolume = true;
    }

    public void Level1()
    {
        soundController.fxGame.PlayOneShot(soundController.select);
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;

    }

    public void Level2()
    {
        soundController.fxGame.PlayOneShot(soundController.select);
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1;

    }
    public void Level3()
    {
        soundController.fxGame.PlayOneShot(soundController.select);
        SceneManager.LoadScene("Level3");
        Time.timeScale = 1;

    }
    public void Level4()
    {
        soundController.fxGame.PlayOneShot(soundController.select);
        SceneManager.LoadScene("Level4");
        Time.timeScale = 1;

    }
    public void Level5()
    {
        soundController.fxGame.PlayOneShot(soundController.select);
        SceneManager.LoadScene("Level5");
        Time.timeScale = 1;

    }
    public void Level6()
    {
        soundController.fxGame.PlayOneShot(soundController.select);
        SceneManager.LoadScene("Level6");
        Time.timeScale = 1;

    }
    public void Sair()
    {
        soundController.fxGame.PlayOneShot(soundController.cancel);
        Debug.Log("Sair Do Jogo");
        Application.Quit();

    }

    public void Info()
    {
        soundController.fxGame.PlayOneShot(soundController.select);
        SceneManager.LoadScene("Credits");
        Time.timeScale = 1;

    }
    public void Continuar()
    {
        soundController.fxGame.PlayOneShot(soundController.confirm);
        TelaInicio.SetActive(false);
        Time.timeScale = 1;

    }
}
