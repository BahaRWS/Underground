using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    int achwai;
    
    // Start is called before the first frame update
    void Start()
    {
       
        achwai = Random.Range(1,4);
        StartCoroutine(range());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator range()
    {
        yield return new WaitForSeconds(0.1f);
        if(achwai == 1)
        {
            transform.position = new Vector2(-21.68f,-4.34f);
        }
        if (achwai == 2)
        {
            transform.position = new Vector2(-18.33f, -21.58f);
        }
        if (achwai == 3)
        {
            transform.position = new Vector2(-6.97f, -16.26f);
        }
    }
}
