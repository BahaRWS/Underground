using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class trap : MonoBehaviour
{

    [SerializeField]
    float plushow = 3.7f;
    Vector3 startpo;

    float Speedd = 1;
    void Start()
    {

        startpo = transform.position;

        StartCoroutine(EAGLEANIMATIO());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator EAGLEANIMATIO()
    {

        bool isflight = true;

        Vector3 endp = new Vector3(startpo.x, startpo.y + plushow, startpo.z);
        float y = 0;

        while (true)
        {
            yield return null;
            if (isflight)
            {
                transform.position = Vector3.Lerp(startpo, endp, y);
            }
            else
                transform.position = Vector3.Lerp(endp, startpo, y);
            y = y + Time.deltaTime * Speedd;
            if (y > 1)
            {
                y = 0;
                isflight = !isflight;

            }
        }
    }
}

