using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("MenuLevel");
        Time.timeScale = 1;
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
        Time.timeScale = 1;
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }
    public void Sair()
    {
        Debug.Log("Sair Do Jogo");
        Application.Quit();
    }
}
