using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject bearr;
    [SerializeField]
    Transform spawnlocation;
    [SerializeField]
    Quaternion spawnrotation;
    [SerializeField]
    zone detectz;
    public float spawntime = 2f;
    private float timespawned = 0f;
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (detectz.detectobjs.Count > 0)
        {
            anim.Play("dooractivate");
            timespawned += Time.deltaTime;
            if (timespawned >= spawntime)
            {

                Instantiate(bearr, spawnlocation.position, spawnrotation);
                timespawned = 0f;
            }

        }
        else
        {
            timespawned = 1f;
            anim.Play("doorsisactivate");
        }

    }
}
