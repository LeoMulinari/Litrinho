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

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        pontos += Time.deltaTime * multiplicadorPontos;
        pontosText.text = $"Distance: {Mathf.FloorToInt(pontos)}m";
        if (pontos >= 100)
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
}
