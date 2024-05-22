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
    public GameObject TelaInicio;
    public GameObject TelaLevelComplete;

    [Header("Configuração UI")]
    public int item1;
    public Text textitem1;
    public Text postextitem1;

    public int item2;
    public Text textitem2;
    public Text postextitem2;

    public int item3;
    public Text textitem3;
    public Text postextitem3;

    [Header("Configuração Sounds")]
    private SoundController soundController;

    void Start()
    {
        soundController = FindObjectOfType(typeof(SoundController)) as SoundController;
        TelaInicio.SetActive(true);
        TelaLevelComplete.SetActive(false);
        Time.timeScale = 0;
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        pontos += Time.deltaTime * multiplicadorPontos;
        pontosText.text = $"Distância: {Mathf.FloorToInt(pontos)}m";
        if (pontos >= 500)
        {
            //soundController.fxGame.PlayOneShot(soundController.itemColetado);
            Time.timeScale = 0;

            TelaLevelComplete.SetActive(true);
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
            soundController.fxGame.PlayOneShot(soundController.hit);
            TelaGameOver.SetActive(true);
            Time.timeScale = 0;

        }
    }

    void Pular()
    {
        soundController.fxGame.PlayOneShot(soundController.jump);
        rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isJumping = true;
    }

    public void ItemText1(int qtditem1)
    {
        item1 += qtditem1;
        textitem1.text = item1.ToString();
        postextitem1.text = textitem1.text;

    }

    public void ItemText2(int qtditem2)
    {
        item2 += qtditem2;
        textitem2.text = item2.ToString();
        postextitem2.text = textitem2.text;

    }

    public void ItemText3(int qtditem3)
    {
        item3 += qtditem3;
        textitem3.text = item3.ToString();
        postextitem3.text = textitem3.text;

    }


}
