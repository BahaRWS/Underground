using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zone2 : MonoBehaviour
{
    public List<Collider2D> detectObjss = new List<Collider2D>();

    // Called when a collider enters the trigger area
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the detected object is the one you are interested in
        if (other.CompareTag("player"))
        {
            // Add the detected object to the list
            detectObjss.Add(other);

            // Do something when the player enters the detection zone

        }
    }
}
    // Called when a collider exits the trigger area
   
