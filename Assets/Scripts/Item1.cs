using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item1 : MonoBehaviour
{

    private Litrinho litrinho1;
    private Rigidbody2D rig_item1;

    // Start is called before the first frame update
    void Start()
    {
        litrinho1 = FindObjectOfType(typeof(Litrinho)) as Litrinho;
        rig_item1 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            litrinho1.ItemText2(1);
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
