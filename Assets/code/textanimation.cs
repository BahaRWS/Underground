using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textanimation : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("scoreanimation");
    }
}
