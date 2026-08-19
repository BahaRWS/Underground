using Pathfinding;
using Pathfinding.Ionic.Zip;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class bossscript : MonoBehaviour
{
    public int maxhp =1;
    int hp;
    public booshp bohp;
    public Transform myboosshp;
    float knoback = 0f;
    public Transform door;
    private Rigidbody2D rb; // Reference to the enemy's Rigidbody2D component
    Animator anim;
    public GameObject sword;
    public int HP;
    public Transform attackzone1;
    public Transform attackzone2;
    
   
    public zone right1;
    public zone left1;


    float nextWaypointdistance = 1f;
    public float moveSpeed = 200f; // Speed at which the enemy moves
    Transform player;
    Seeker seeker;
    Path path;
    int currentWayPoint;
    bool reachedEndPoint;
    bool canmove = true;
    Vector2 place;
    SpriteRenderer sp;
    bool isattack;
    bool die;
    bool supermove;
    
    // Start is called before the first frame update
    void Start()
    {
        sword.SetActive(false); 
        supermove = true;
        die = false;
        isattack = false;
        hp = maxhp;
        bohp.boosmaxhp(hp);
        myboosshp.gameObject.SetActive(true);
        player = GameObject.FindGameObjectWithTag("player").transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>(); 
      
        seeker = GetComponent<Seeker>();
        InvokeRepeating("updatepath", 0, 0.25f);

    }
    void updatepath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, player.position, OnPathComplete);
        }
    }
    void OnPathComplete(Path p)
    {

        if (!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (right1.detectobjs.Count > 0|| left1.detectobjs.Count > 0)
        {
            anim.Play("boosattack");
            StartCoroutine(superattack());
        }
        if (canmove == false)
        {
            transform.position = place;
            anim.SetFloat("speed", 0);
        }

        if (player.position.x > transform.position.x)
        {
            sp.flipX = false;
            right1.gameObject.SetActive(true);
            left1.gameObject.SetActive(false);
        }
        else
        {
            sp.flipX = true;
            right1.gameObject.SetActive(false);
            left1.gameObject.SetActive(true);
        }
        if (isattack == true & sp.flipX == false&&die==false)
        {

            attackzone1.gameObject.SetActive(true);



            StartCoroutine(E());
        }
        else if (isattack == true & sp.flipX == true&&die==false)
        {

            attackzone2.gameObject.SetActive(true);
            StartCoroutine(E());


        }
   

    }
    public void baha(int damage)
    {
        hp = hp - damage;
        bohp.setattackborder(hp);
        transform.position = new Vector2(transform.position.x + knoback, transform.position.y);
        if (hp <= 0)
        {
            sword.SetActive(true);
            sword.transform.position = transform.position;
            anim.SetBool("isdie", true);
            die = true;
            Destroy(gameObject, 1.40f);
            myboosshp.gameObject.SetActive(false);

            door.gameObject.SendMessage("unlockall");
        }

    }
    public void ha(int damage)
    {
        hp = hp - damage;
        bohp.setattackborder(hp);
        transform.position = new Vector2(transform.position.x - knoback, transform.position.y);
        if (hp <= 0)
        {
            sword.SetActive(true);
            sword.transform.position = transform.position;
            anim.SetBool("isdie", true);
            die = true;
            Destroy(gameObject, 1.40f);
            myboosshp.gameObject.SetActive(false);

            door.gameObject.SendMessage("unlockall");
        }

    }
    private void FixedUpdate()
    {
        
            if (path == null)
                return;
        if (currentWayPoint >= path.vectorPath.Count)
        {
            reachedEndPoint = true;
           
            

            return;
        }
        else
        
        {
            reachedEndPoint = false;
            
           
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
        if (supermove)
        {
            Vector2 force = direction * moveSpeed;
            rb.AddForce(force);
        }
        else if (supermove == false)
        {
            Vector2 force = (direction * moveSpeed) / 2;
            rb.AddForce(force);
        }

     
        
            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);
            if (distance < nextWaypointdistance)
                currentWayPoint++;
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "posion")
        {
            supermove = false;
      
            StartCoroutine(posionbye());
            StartCoroutine(RepeatFunction());
        }
    }
    IEnumerator posionbye()
    {
        yield return new WaitForSeconds(15);
        supermove = true;

    }
    IEnumerator RepeatFunction()
    {

        // Call the function you want to repeat here

        sp.color = Color.yellow;

        yield return new WaitForSeconds(15f);

        // Update the elapsed time

        sp.color = Color.white;


    }

    public void unlockmove()
    {
        canmove = false;
        place = new Vector2(transform.position.x, transform.position.y);
          
    }
    public void lockmove()
    {
        canmove = true;
        InvokeRepeating("update", 0, 0.05f);

    }
    private void update()
    
    {

        if (Mathf.Abs(rb.velocity.x) > 0.1f || Mathf.Abs(rb.velocity.y) > 0.1f) anim.SetFloat("speed", 1);
        else anim.SetFloat("speed", 0);

       
    }
    IEnumerator E()
    {
        yield return new WaitForSeconds(0.5f);
        attackzone1.gameObject.SetActive(false);
        attackzone2.gameObject.SetActive(false);
        isattack = false;
    }
    IEnumerator superattack()
    {
        yield return new WaitForSeconds(0.3f);
        isattack = true;
    }
}
