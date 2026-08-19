using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;



public class redzone : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 target;
    bool isbring;
    public GameObject posiontrigger;
    public demoscript demo;
    public float clickRadius = 0.5f; // Adjust this radius to your liking
    private void Start()
    {
        isbring = true;
    }
    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0) )
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Check if the mouse click is within the clickRadius of the sprite
            if (Vector2.Distance(mousePosition, transform.position) <= clickRadius)
            {
                // The mouse click is within the specified radius of the sprite
                // Create and instantiate the circle prefab at the mouse position
                GameObject circle = Instantiate(posiontrigger, mousePosition, Quaternion.identity);
                demo.gameObject.SendMessage("useposion");
                // Destroy the circle after a certain time (if needed)
                Destroy(circle, 2.0f);
            }
        }
    }
    public void nobring()
    {
        isbring = false;
    }
    public void bring()
    {
        isbring = true;
    }

}
