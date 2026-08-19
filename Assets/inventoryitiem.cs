using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI; 

public class inventoryitiem : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    
    public Image image;
    [Header("UI")]
    public Text countText;

    [HideInInspector] public int count = 1;
    [HideInInspector] public Item item;
    [HideInInspector] public Transform parentAfterDrag;
  
    public void InitializeItem(Item newItem)
    {
        item = newItem; 
        image.sprite = newItem.image;
        RefreshCount();
    }
    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool TextActive = count > 1;
        countText.gameObject.SetActive(TextActive);
    }
    public void OnBeginDrag(PointerEventData eventdata)
    {
        
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }
    public void OnDrag(PointerEventData eventdata)
    {
      
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventdata)
    {
       image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
    }

  
}
