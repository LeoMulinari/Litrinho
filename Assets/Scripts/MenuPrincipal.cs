using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void Jogar()
    {
        SceneManager.LoadScene("MenuLevel");
    }

    public void VoltarMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Sair()
    {
        Debug.Log("Sair Do Jogo");
        Application.Quit();
    }
}
