using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class camera1 : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
    bool cancontrol;
    [SerializeField] private Transform target1;
    // Start is called before the first frame update
    void Start()
    {
        cancontrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (cancontrol==true)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        else if (cancontrol == false)
        {
            Vector3 targetPosition = target1.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
    public void unlock()
    {
        cancontrol = false;
    }
    public void lock1()
    {
        cancontrol = true;
    }
}
