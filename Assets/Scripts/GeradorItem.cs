using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorItem : MonoBehaviour
{
    public GameObject[] itemPrefabs;

    private Rigidbody2D rig_item;
    public float delayInicial;
    public float delayEntreInimigo;

    public float distanciaMinima = 20f;
    public float distanciaMaxima = 30f;

    private float distanciaNecessaria;
    private float distanciaAtual;

    void Start()
    {
        rig_item = GetComponent<Rigidbody2D>();
        StartCoroutine(SpawnItem());
    }

    private IEnumerator SpawnItem()
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
                distanciaNecessaria = Random.Range(distanciaMinima, distanciaMaxima);
            }
            yield return null;
        }
    }
}
