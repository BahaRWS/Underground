using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sellerscript : MonoBehaviour
{
    public TextMeshProUGUI number;
    public TextMeshProUGUI xtext;
    public Transform buy;
    public Transform buypotion;
    public Transform buypotion1;
    public Transform imagecoin;
    // Start is called before the first frame update
    void Start()
    {
        xtext.gameObject.SetActive(false);
        buypotion1.gameObject.SetActive(false); 
        buy.gameObject.SetActive(false);
        buypotion.gameObject.SetActive(false);  
        number.gameObject.SetActive(false);
        imagecoin.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void coin()
    {
        xtext.gameObject.SetActive(true);
        xtext.text = "IT ALLOW YOU TO ENTER IN THE BOSS ROOM";
        number.gameObject.SetActive(true);
        number.text = "" + 5;
        imagecoin.gameObject.SetActive(true);
    }
    public void potion()
    {
        xtext.gameObject.SetActive(true);
        xtext.text = "INCREASE YOUR HEALTH";
        number.gameObject.SetActive(true);
        number.text = "" + 4;
        imagecoin.gameObject.SetActive(true);
    }
    public void potion1()
    {
        xtext.gameObject.SetActive(true);
        xtext.text = "INCREASE YOUR SPEED: +50%";
        number.gameObject.SetActive(true);
        number.text = "" + 2;
        imagecoin.gameObject.SetActive(true);
    }
    public void potion2()
    {
        xtext.gameObject.SetActive(true);
        xtext.text = "it is a poison that can decrease" +
            " the defense of your opponent by -1";
        number.gameObject.SetActive(true);
        number.text = "" + 2;
        imagecoin.gameObject.SetActive(true);
    }
}
