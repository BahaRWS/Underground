using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
public class trap2 : MonoBehaviour
{

    
    Vector3 startp;

    float Speed = 1;
    void Start()
    {

        startp = transform.position;
       
        StartCoroutine(EAGLEANIMATION());
         
    }

    // Update is called once per frame
    void Update()
    {


    }
    
    IEnumerator EAGLEANIMATION()
    {

        bool isflight = true;

        Vector3 endp = new Vector3(startp.x+3.7f, startp.y , startp.z);
        float y = 0;

        while (true)
        {
            yield return null;
            if (isflight)
            {
                transform.position = Vector3.Lerp(startp, endp, y);
            }
            else
                transform.position = Vector3.Lerp(endp, startp, y);
            y = y + Time.deltaTime * Speed;
            if (y > 1)
            {
                y = 0;
                isflight = !isflight;

            }
        }
    } 
}
