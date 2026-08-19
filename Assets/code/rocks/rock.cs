using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock : MonoBehaviour
{
    int achwai;
    bool isveryrock;
    public GameObject sadik1;
    public GameObject sadik2;
    public GameObject chest1;

    // Start is called before the first frame update
    void Start()
    {
        chest1.SetActive(false); 
        achwai = Random.Range(1, 4);
        StartCoroutine(range());

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator range()
    {
        yield return new WaitForSeconds(0.1f);
        if (achwai == 1)
        {
            isveryrock = true;
        }
        if (achwai == 2)
        {
            sadik1.SendMessage("you",1); 
        }
        if (achwai == 3)
        {
            sadik2.SendMessage("you",1); 
        }
    }
    public void isyou()
    {
        if (isveryrock==true)
        {
            chest1.SetActive(true);
        }
    }
}
