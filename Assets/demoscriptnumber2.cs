using System.Collections;
using System.Collections.Generic;

using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class demoscriptnumber2 : MonoBehaviour
{
    public inventorymanager inventorymanager;
    public Item[] itemsToPickup;
    public GameObject player;
  
    
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
            if (id == 1)
            {
                player.SendMessage("speedpotion");
            }
            if (id == 2)
            {
                player.SendMessage("posionpotion");
            }
       
        }
        else
        {
            Debug.Log("Inventory is full, item not added");
        }
    }
    public void Start()
    {
        
       

    }

    public void UseSelectitem()
    {
        Item receivedItemm = inventorymanager.GetSelectedItem(false);
        if (receivedItemm.name != ("posion") )
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


}
