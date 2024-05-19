using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    private Litrinho litrinho;
    private Rigidbody2D rig_item;

    // Start is called before the first frame update
    void Start()
    {
        litrinho = FindObjectOfType(typeof(Litrinho)) as Litrinho;
        rig_item = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            litrinho.ItemText1(1);
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
