using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorObstaculo : MonoBehaviour
{
    public GameObject obstaculoPrefab;
    public float obstaculoTempo;
    public float obstaculoVelocidade;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnObstaculo");
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnObstaculo()
    {

        yield return new WaitForSeconds(obstaculoTempo);
        GameObject ObjetoObstaculoTemp = Instantiate(obstaculoPrefab);
        StartCoroutine("SpawnObstaculo");
    }
}


