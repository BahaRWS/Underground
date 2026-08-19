using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class inventoryslot : MonoBehaviour,IDropHandler 
{
    public Image image;
    public Color selectcolor, notselectcolor;
    public void Awake()
    {
        DeSelect();
    }
    public void Select()
    {
        image.color = selectcolor;
    }
    public void DeSelect()
    {
        image.color = notselectcolor;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            inventoryitiem  inventoryitem = eventData.pointerDrag.GetComponent<inventoryitiem>();
            inventoryitem.parentAfterDrag = transform; 
        }
    }

}
   

