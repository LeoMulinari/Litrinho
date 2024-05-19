using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : MonoBehaviour
{

    private Litrinho litrinho2;
    private Rigidbody2D rig_item2;

    // Start is called before the first frame update
    void Start()
    {
        litrinho2 = FindObjectOfType(typeof(Litrinho)) as Litrinho;
        rig_item2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            litrinho2.ItemText3(1);
            Debug.Log("coletou");
            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
        Debug.Log("item destruido");
    }
}
