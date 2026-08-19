using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using Pathfinding;

public class bearcontroller : MonoBehaviour
{
     // Reference to the player's Transform
    private Rigidbody2D rb; // Reference to the enemy's Rigidbody2D component
    private Animator anim;
    public zone2 dete;
    public float HP;
    public float knoback;
     float nextWaypointdistance=1f;
    public float moveSpeed = 200f; // Speed at which the enemy moves
     Transform player;
    Seeker seeker;
    Path path;
    int currentWayPoint;
    bool reachedEndPoint;
    bool canmove;
    
    bool supermove = true;
    SpriteRenderer sp;

    
    





    void Start()
    {
        sp = GetComponent<SpriteRenderer>(); 
        canmove = true;
        player = GameObject.FindGameObjectWithTag("player").transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        HP = 3;
        knoback = 2f;
       seeker = GetComponent<Seeker>();
        InvokeRepeating("updatepath",0,0.25f); 
        
       
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
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "posion")
        {
            supermove = false;
            
          
            StartCoroutine(RepeatFunction ());
        }
    }

    private void Update()
    {
                if (rb.velocity.x < -0.1f || rb.velocity.x > 0.1f || rb.velocity.y < -0.1f || rb.velocity.y > 0.1f) anim.SetFloat("speed", 1);
        else anim.SetFloat("speed", 0);
        
        if (rb.velocity.x > 0.1f)
            anim.SetFloat("Blend", 1f);
        if (rb.velocity.x < -0.1f)
            anim.SetFloat("Blend", -1f);
        if (HP <= 0)
        {
            Destroy(gameObject);
            player.gameObject.SendMessage("coin"); 
        }
    }
    private void baha(int damage)
    {
       
       HP =HP - damage;
        transform.position = new Vector2(transform.position.x + knoback, transform.position.y);
         
        
    }
    private void ha(int damage)
    {
        HP = HP - damage;
      transform.position = new Vector2(transform.position.x - knoback, transform.position.y); ;
    }
    private void FixedUpdate()
    {
        if(canmove==true){
            if (path == null)
                return;
            if (currentWayPoint >= path.vectorPath.Count)
            {
                reachedEndPoint = true;
                return;
            }
            else reachedEndPoint = false;
            
            Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint] - rb.position).normalized;
            if (supermove)
            {
                Vector2 force = direction * moveSpeed;
                rb.AddForce(force);
            }
            else if (supermove == false)
            {
                Vector2 force = (direction * moveSpeed)/2;
                rb.AddForce(force);
            }
         
            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);
            if (distance < nextWaypointdistance)
                currentWayPoint++;
        }
    }

    IEnumerator RepeatFunction()
    {

        // Call the function you want to repeat here

        sp.color = Color.yellow;
        HP = HP - 0.5f;

        yield return new WaitForSeconds(15f);
         
            // Update the elapsed time
           
            sp.color = Color.white;
        supermove = true;

    }





}