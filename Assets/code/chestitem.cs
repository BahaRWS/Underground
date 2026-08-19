using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class chestitem : MonoBehaviour
{

    public Transform player;
    public GameObject potion;
    public GameObject potion1;
    int number;

    public void Start()
    {
        number = Random.Range(1, 3);
        player.gameObject.SendMessage("scoree");
        StartCoroutine(C());
    }


    
    IEnumerator C()
    {
        yield return new WaitForSeconds(0.1f);
           
        if (number == 1)
        {
           potion.SetActive(true);
            Destroy(potion1);
           
        }
        if (number == 2)
        {
           potion1.gameObject.SetActive(true);
            Destroy(potion);

        }
    }

}


