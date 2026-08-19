using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject projectile;
    [SerializeField]
    Transform  spawnlocation;
    [SerializeField]
    Quaternion spawnrotation;
    [SerializeField]
    zone detectz;
    public float spawntime = 0.5f;
    private float timespawned = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (detectz.detectobjs.Count > 0)
        {
            timespawned += Time.deltaTime;
            if (timespawned >= spawntime)
            {

                Instantiate(projectile, spawnlocation.position, spawnrotation);
                timespawned = 0f;
            }

        }else
            timespawned = 1f;

    }
}
