using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    private SoundController soundController;

    public GameObject TelaInicio;

    void Start()
    {
        soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
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

    public void Level1()
    {
        soundController.fxGame.PlayOneShot(soundController.select);
        SceneManager.LoadScene("Level1");
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
