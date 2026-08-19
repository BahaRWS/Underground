using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class border2 : MonoBehaviour
{
    public GameObject superpress;
    // Start is called before the first frame update
    void Start()
    {
        superpress.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            superpress.SetActive(true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            superpress.SetActive(false);
        }
    }
    
    
   
    

}
