using Cainos.PixelArtPlatformer_VillageProps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rock1 : MonoBehaviour
{
    public GameObject chest1;
    bool isrock;
    // Start is called before the first frame update
    void Start()
    {
        isrock = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void you(int value)
    {
        if (value == 1)
        {
            isrock = true;
        }
    }
    public void isyou()
    {
        if (isrock == true)
        {
            chest1.SetActive(true);
        }
    }
}
