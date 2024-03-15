using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentar : MonoBehaviour
{
    public Vector2 direction;
    public float speed;


    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
