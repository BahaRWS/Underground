using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class playerbear : MonoBehaviour
{
    
   
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bear"|| collision.tag == "boos")
        {
            collision.gameObject.SendMessage("baha",1);

        }
        
    }
}
