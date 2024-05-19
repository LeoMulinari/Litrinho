using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Litrinho : MonoBehaviour
{

    private bool isJumping = false;
    public float speed;
    public float jumpForce;
    private float pontos;
    public float multiplicadorPontos = 1;
    public Text pontosText;
    private Rigidbody2D rig;
    float direction;
    public GameObject TelaGameOver;
    public GameObject TelaLevelComplete;

    [Header("Configuração UI")]
    public int item1;
    public Text textitem1;

    public int item2;
    public Text textitem2;

    public int item3;
    public Text textitem3;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        pontos += Time.deltaTime * multiplicadorPontos;
        pontosText.text = $"Distância: {Mathf.FloorToInt(pontos)}m";
        if (pontos >= 500)
        {
            TelaLevelComplete.SetActive(true);
            Time.timeScale = 0;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isJumping == false)
        {
            Pular();
        }
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {

        if (colisor.gameObject.layer == 9)
        {
            isJumping = false;
        }

        if (colisor.gameObject.CompareTag("Inimigo"))
        {
            TelaGameOver.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void Pular()
    {
        rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isJumping = true;
    }

    public void ItemText1(int qtditem1)
    {
        item1 += qtditem1;
        textitem1.text = item1.ToString();

    }

    public void ItemText2(int qtditem2)
    {
        item2 += qtditem2;
        textitem2.text = item2.ToString();

    }

    public void ItemText3(int qtditem3)
    {
        item3 += qtditem3;
        textitem3.text = item3.ToString();

    }
}
