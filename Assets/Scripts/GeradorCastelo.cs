using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorCastelo : MonoBehaviour
{

    public GameObject casteloPrefab;
    public GameObject[] itemPrefabs;
    public float delayInicial;
    public float delayEntreInimigo;

    public float distanciaMinima = 4f;
    public float distanciaMaxima = 8f;

    public float distanciaMinima1 = 15f;
    public float distanciaMaxima1 = 30f;
    private float distanciaNecessaria;
    private float distanciaAtual;

    private void Start()
    {
        StartCoroutine(GerarInimigo());

    }

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
                var quantidadeItem = itemPrefabs.Length;
                var indiceAleatorio = Random.Range(0, quantidadeItem);
                var itemPrefab = itemPrefabs[indiceAleatorio];
                ultimoInimigoGerado = Instantiate(casteloPrefab, transform.position, Quaternion.identity);
                ultimoInimigoGerado = Instantiate(itemPrefab, new Vector2(transform.position.x + (Random.Range(4, 7)), transform.position.y), Quaternion.identity);
                distanciaNecessaria = Random.Range(distanciaMinima, distanciaMaxima);
            }
            yield return null;
        }
    }

    /*private IEnumerator SpawnItem()
    {
        yield return new WaitForSeconds(delayInicial);
        GameObject ultimoItemGerado = null;
        var distanciaNecessaria = 0f;

        while (true)
        {
            var geracaoObjetoLiberada =
           ultimoItemGerado == null
           || Vector3.Distance(transform.position, ultimoItemGerado.transform.position) >= distanciaNecessaria;

            this.distanciaNecessaria = distanciaNecessaria;

            if (ultimoItemGerado != null)
            {
                distanciaAtual = Vector3.Distance(transform.position, ultimoItemGerado.transform.position);
            }

            if (geracaoObjetoLiberada)
            {
                var quantidadeItem = itemPrefabs.Length;
                var indiceAleatorio = Random.Range(0, quantidadeItem);
                var itemPrefab = itemPrefabs[indiceAleatorio];
                ultimoItemGerado = Instantiate(itemPrefab, transform.position, Quaternion.identity);
                distanciaNecessaria = Random.Range(distanciaMinima1, distanciaMaxima1);
            }
            yield return null;
        }
    }*/
}
