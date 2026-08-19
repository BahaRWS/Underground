using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventorymanager : MonoBehaviour
{
    public int maxStackedItems = 2;
    public inventoryslot[] inventoryslots;
    public GameObject inventoryitemPrefab;
    int selectedSlot = -1;
    public static inventorymanager instance;
    


    private void Start()
    {
        Changeselectslot(0);
        instance = this;
    }
    public void select1()
    {
        Changeselectslot(0);
    }
    public void select2()
    {
        Changeselectslot(1);
    }
    public void select3()
    {
        Changeselectslot(2);
    }
    public void select4()
    {
        Changeselectslot(3);
    }
    public void select5()
    {
        Changeselectslot(4);
    }
   

        private void Update()
        {
           for (int i = 1; i <= 5; i++)
           {
                if (Input.GetKeyDown(i.ToString()))
                {
                    Changeselectslot(i - 1);
               }
           }

            // Check for mouse scroll input
            float scroll = Input.GetAxis("Mouse ScrollWheel");

            if (scroll > 0f) // Scrolling up
            {
                // Increment selected slot (scrolling up)
                Changeselectslot((selectedSlot + 1) % inventoryslots.Length);
            }
            else if (scroll < 0f) // Scrolling down
            {
                // Decrement selected slot (scrolling down)
                Changeselectslot((selectedSlot - 1 + inventoryslots.Length) % inventoryslots.Length);
            }
        }
    
    void Changeselectslot(int newValue)
    {
        if (selectedSlot >= 0) { 
        inventoryslots[selectedSlot].DeSelect();
         }
        inventoryslots[newValue].Select();
        selectedSlot = newValue;
    }
    // Start is called before the first frame update
    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventoryslots.Length; i++)
        {
            inventoryslot slot = inventoryslots[i];
            inventoryitiem itemInSlot = slot.GetComponentInChildren<inventoryitiem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStackedItems
                &&itemInSlot.item.stackable==true)
            {
                
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }
        for (int i =0;i<inventoryslots.Length;i++)
        {
            inventoryslot slot = inventoryslots[i];
            inventoryitiem itemInSlot = slot.GetComponentInChildren<inventoryitiem>();
            if(itemInSlot==null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }
   
            return false;

        
    }
    void SpawnNewItem(Item item,inventoryslot slot)
    {
        GameObject newItemGo = Instantiate(inventoryitemPrefab,slot.transform);
        inventoryitiem inventoryitem = newItemGo.GetComponent<inventoryitiem >();
        inventoryitem.InitializeItem(item);
    }
    public Item GetSelectedItem(bool use)
    {
        inventoryslot slot = inventoryslots[selectedSlot];
        inventoryitiem itemInSlot = slot.GetComponentInChildren<inventoryitiem>();
        if (itemInSlot != null )
        {
            Item item = itemInSlot.item;
            if (use == true)
           {
                itemInSlot.count--;
               if(itemInSlot.count<=0)
               {
                    Destroy(itemInSlot.gameObject);
                }
               else {
                    itemInSlot.RefreshCount();
               }
            }
            return item;
        }
        return null;
    }
    
}
