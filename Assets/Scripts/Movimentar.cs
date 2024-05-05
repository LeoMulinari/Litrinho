using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentar : MonoBehaviour
{
    public Vector2 direction;
    public float velocidade;

    private Jogo jogoScript;


    void Start()
    {
        jogoScript = GameObject.Find("Jogo").GetComponent<Jogo>();
    }
    void Update()
    {
        transform.Translate(direction * jogoScript.velocidade * Time.deltaTime);

    }
}
