using System.Collections;
using System.Collections.Generic;

using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class demoscript : MonoBehaviour
{
    public inventorymanager inventorymanager;
    public Item[] itemsToPickup;
    public GameObject player;
    public GameObject sworded;
    bool canposion;
    public void PickupItem(int id)
    {
        Item itemToPickup = itemsToPickup[id];

        // Create a copy of the item before adding it to the inventory
        //Item itemCopy = new Item(itemToPickup); // Assuming you have a copy constructor or cloning mechanism for your Item class

        bool result = inventorymanager.AddItem(itemToPickup);

        if (result == true)
        {
            Debug.Log("Item added to the inventory");
            if (id == 0)
            {
                player.SendMessage("healthpotion"); 
            }
        
            if (id == 2)
            {
                player.SendMessage("posionpotion");
            }
            if (id == 1)
            {
                Destroy(sworded.gameObject);
            }
        }
        else
        {
            Debug.Log("Inventory is full, item not added");
        }
    }
    public void Start()
    {
        InvokeRepeating("GetSelectedItem", 0, 0.1f);
        canposion = true;
        

    }
    public void GetSelectedItem()
    {
        Item receivedItem = inventorymanager.GetSelectedItem(false);
        if (receivedItem != null)
        {

            if (receivedItem.name == ("posion") && canposion == true)
            {
                player.SendMessage("posionready");

            }
            else player.SendMessage("posionnotready");
            if (receivedItem.name == ("sword1"))
            {
                player.SendMessage("sword1ready");
            }
            else player.SendMessage("sword1notready");
            if (receivedItem.name == ("miftah"))
            {
                player.SendMessage("miftahready");
            }
            else player.SendMessage("miftahnotready"); 
            
        }
        else { player.SendMessage("posionnotready");
        player.SendMessage("sword1notready");
            player.SendMessage("miftahnotready");
        }

    }
    public void UseSelectitem()
    {
        Item receivedItemm = inventorymanager.GetSelectedItem(false);
        if (receivedItemm.name != ("posion")&& receivedItemm.name != ("sword1"))
        {
            Item receivedItem = inventorymanager.GetSelectedItem(true);
            if (receivedItem != null)
            {

                if (receivedItem.name == ("Digging block"))
                {
                    player.SendMessage("usepotion");
                }
                if (receivedItem.name == ("potionnew"))
                {
                    player.SendMessage("usepotion1");
                }
            }
            else
            {
                Debug.Log("noitemused");
            }
        }
        
    }
    public void useposion()
    {
 
            Item receivedItem = inventorymanager.GetSelectedItem(true);
          //  if (receivedItem != null)
         //   {

         //   }
    
    }
    public void sword1()
    {
        PickupItem(1);
    }
    public void posioinrightnow()
    {
 StartCoroutine(readypotion()); 
    }
    public void posionnotrightnow()
    {
        canposion = false;
    }
    IEnumerator readypotion()
    {
        yield return new WaitForSeconds(0.05f);
        canposion = true;
    }
    public void useit()
    {
        Item receivedItem = inventorymanager.GetSelectedItem(true);
    }

}

