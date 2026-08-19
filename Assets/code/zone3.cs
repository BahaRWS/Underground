using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zone3 : MonoBehaviour
{
    // Start is called before the first frame update
   [SerializeField]
   GameObject square;
    [SerializeField]
   GameObject square2;
    public List<Collider2D> detectobjs = new List<Collider2D>();

    public GameObject doorn;
    public Transform boss;
    public Transform cameraa;
    public Transform player;

    
    
    
    Animator anim;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {


    }
   public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            detectobjs.Add(collision);
           
           square.gameObject.SetActive(true);
        
            square2.gameObject.SetActive(true);
            player.gameObject.SendMessage("unlock");
           
            doorn.SendMessage("unlock");
            boss.gameObject.SetActive(true);
            cameraa.gameObject.SendMessage("unlock");
            boss.gameObject.SendMessage("unlockmove");                            
            StartCoroutine(after());
            square2.gameObject.SetActive(true);
        }


    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            detectobjs.Remove(collision);
         //   square.gameObject.SetActive(false);
            
         //  square2.gameObject.SetActive(false);
        }


    }
    IEnumerator after()
    {
        yield return new WaitForSeconds(2);
        player.gameObject.SendMessage("lock1");

        doorn.SendMessage("lock1");
        boss.gameObject.SendMessage("lockmove");
        cameraa.gameObject.SendMessage("lock1");
       
    }
    public void unlockall()
    {
        Destroy(square.gameObject);

        Destroy(square2.gameObject);

    }

}

