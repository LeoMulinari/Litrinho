using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorCastelo : MonoBehaviour
{

    public GameObject casteloPrefab;

    public float delayInicial;
    public float delayEntreInimigo;

    public float distanciaMinima = 4f;
    public float distanciaMaxima = 8f;

    // Start is called before the first frame update
    private void Start()
    {
        //InvokeRepeating("GerarInimigo", delayInicial, delayEntreCastelos);
        StartCoroutine(GerarInimigo());
    }

    // Update is called once per frame

    private float distanciaNecessaria;
    private float distanciaAtual;
    private IEnumerator GerarInimigo()
    {

        yield return new WaitForSeconds(delayInicial);
        GameObject ultimoInimigoGerado = null;

        var distanciaNecessaria = 0f;


        while (true)
        {


            var geracaoObjetoLiberada =
            ultimoInimigoGerado == null
            || Vector3.Distance(transform.position, ultimoInimigoGerado.transform.position) >= distanciaNecessaria;

            this.distanciaNecessaria = distanciaNecessaria;

            if (ultimoInimigoGerado != null)
            {
                distanciaAtual = Vector3.Distance(transform.position, ultimoInimigoGerado.transform.position);
            }

            if (geracaoObjetoLiberada)
            {
                ultimoInimigoGerado = Instantiate(casteloPrefab, transform.position, Quaternion.identity);
                distanciaNecessaria = Random.Range(distanciaMinima, distanciaMaxima);
            }

            yield return null;
            //yield return new WaitForSeconds(delayEntreInimigo);
        }

    }
}
