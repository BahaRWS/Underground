using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class zone : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Collider2D> detectobjs = new List<Collider2D>();


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            detectobjs.Add(collision);
        }
        

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            detectobjs.Remove(collision);
        }


    }

}
