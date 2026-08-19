using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrows : MonoBehaviour
{
    public float speed = 1;
    public float timelive = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * transform.right * Time.deltaTime;
        Destroy(gameObject,timelive);
    }
}
