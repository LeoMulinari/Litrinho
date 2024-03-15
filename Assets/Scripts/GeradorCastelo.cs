using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorCastelo : MonoBehaviour
{

    public GameObject casteloPrefab;

    public float delayInicial;
    public float delayEntreCastelos;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("GerarCastelo", delayInicial, delayEntreCastelos);
    }

    // Update is called once per frame
    private void GerarCastelo()
    {
        Instantiate(casteloPrefab, transform.position, Quaternion.identity);
    }
}
