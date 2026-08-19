//#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.Rendering;
using TMPro;
//using UnityEngine.WSA;
//using JetBrains.Annotations;
//using UnityEditor.U2D;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class cc : MonoBehaviour
{
    public GameObject theblackpanel;
    public GameObject newborder;
    public GameObject chest2;
    public GameObject press2;
    public GameObject post;
    public GameObject sound;
    public GameObject sound1;
    public GameObject attackzone3;
    public GameObject attackzone4;
    public GameObject sword;
    public GameObject posionzone;
    public GameObject supertext;
    public Transform bartool;
    public Transform presst;
    public Transform bahaborder;
    public Transform press;
    public GameObject presschest;
    public Transform sellerpanel;
    public Transform chestpanel;
    [SerializeField]
    Transform objj;
    public attack attackcontroller;
    bool candor = true;
    bool issword1;

    
    int speed = 400;
    Rigidbody2D rb;
    SpriteRenderer sp;
    Animator anim;
    Vector2 move;
    public int HP;
    public int M = 5;
    TextMeshProUGUI H;
    public healthbar bar;
    public Transform useyes;
    
    public Transform attackzone1;
    bool isattack;
    public Transform attackzone2;
    float attacktime=0f;
    
    bool canmove = true;
    public float idlefriction = 0.9f;
    bool canattack;
    float attackingtime = 2;
   int maxattack = 100;
    int att;
    float repeatDuration = 50f;
    private float elapsedTime = 0f;
    Vector2 place;
    TextMeshProUGUI S;
    TextMeshProUGUI key;
    public Transform holder;
    int score = 5;
    bool ispressed;
    int keynumber = 0;
    public demoscriptnumber2 script;
    public demoscript xscript;
    public GameObject rushing;
    bool ismiftahready =false;
   

    // Start is called before the first frame update
    void Start()
    {
        theblackpanel.SetActive(false); 
        chest2.SetActive(false); 
        press2.SetActive(false); 
        post.SetActive(false);
        sound.SetActive(true);
        sound1.SetActive(false);
        attackzone3.SetActive(false);
        attackzone4.SetActive(false);
        issword1 = false;
        posionzone.SetActive(false); 
        supertext.SetActive(false);
        chestpanel.gameObject.SetActive(false);  
        presschest.SetActive(false);
        bartool.gameObject.SetActive(false);
        ispressed = false;
        press.gameObject.SetActive(false);
        bahaborder.gameObject.SetActive(true);
        presst.gameObject.SetActive(false);
        sellerpanel.gameObject.SetActive(false);
        att = maxattack;
        isattack = false;
        attacktime = 0;
        canattack = true;
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>(); 
        anim = GetComponent<Animator>();
        M = HP;
        bar.setMaxhealth(HP);
        attackcontroller.canattack(att);
        S = holder.Find("score").GetComponent<TextMeshProUGUI>();
        S.text = ""+score;
        key = holder.Find("keynumber").GetComponent<TextMeshProUGUI>();
        key.text = "" + keynumber;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            xscript.gameObject.SendMessage("UseSelectitem"); 
        }

        if (HP <= 0)
        {
            OnMove();
            anim.SetBool("ishurt", true);

            StartCoroutine(A());
        }

        move.x = Input.GetAxisRaw("Horizontal");
            move.y = Input.GetAxisRaw("Vertical");
            move.Normalize();

            anim.SetFloat("horizontal", move.x);
            anim.SetFloat("vertical", move.y);
            anim.SetFloat("speed", move.sqrMagnitude);
            if (Input.GetAxis("Horizontal") > 0&&candor==true)
            {

                sp.flipX = false;
            }
            if (Input.GetAxis("Horizontal") < 0&&candor==true)
            {

                sp.flipX = true;
            }
        
        if (Input.GetButtonDown("Jump")&&canattack == true)
        {
            canattack = false;
           
            att = 0;
            attackcontroller.setattackborder(att);
            StartCoroutine(RepeatFunction());
            anim.Play("attack");
            candor = false;
            StartCoroutine(attackcontrollerr());
            
        }
        if (isattack == true & sp.flipX == false&&issword1==false)
        {
          
            attackzone1.gameObject.SetActive(true);



            StartCoroutine(E());
        }
        else if (isattack == true & sp.flipX == true&&issword1==false)
        {
          
            attackzone2.gameObject.SetActive(true);
            StartCoroutine(E());


        }
        if (isattack == true & sp.flipX == false && issword1 == true)
        {

            attackzone3.gameObject.SetActive(true);



            StartCoroutine(E());
        }
        else if (isattack == true & sp.flipX == true && issword1 == true)
        {

            attackzone4.gameObject.SetActive(true);
            StartCoroutine(E());


        }

        if (canattack == false)
        {

           


            attacktime += Time.deltaTime;


            if (attacktime > attackingtime)
            {
                elapsedTime = 0;
                canattack = true;
                
                attacktime = 0;
                att = maxattack;
                attackcontroller.setattackborder(att);
            }
            return;
        }
       
        



    }
    
    private void FixedUpdate()
    {
        if (canmove == true && move != Vector2.zero)
        {
            rb.velocity = new Vector2(speed * move.x * Time.fixedDeltaTime, rb.velocity.y);
            rb.velocity = new Vector2(rb.velocity.x, speed * move.y * Time.fixedDeltaTime);
        }
        else rb.velocity = Vector2.Lerp(rb.velocity,Vector2.zero,idlefriction);
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
 
        if (collision.tag == "trap" && HP > 0)
        {

            HP = HP - 1;
            hurt(1);
            Debug.Log(HP);
            
            Transform obj = Instantiate(objj, collision.transform.position, new Quaternion());
            obj.gameObject.SetActive(true);
            Destroy (obj.gameObject,0.5f);
            if (HP >= 1)
            {
                sp.material.color = Color.red;
                StartCoroutine(F());
            }

   
        }
        if (collision.tag == "sword") {

            xscript.SendMessage("sword1");
        }
        if (collision.tag == "superdoor")
        {
            transform.position = new Vector2(-71.34f,61.53f);
            sound1.SetActive(true);
            sound.SetActive(false);
            post.SetActive(true);
            theblackpanel.SetActive(true);
            unlock();
            StartCoroutine(white());
        }
        if (collision.tag == "superdoor1")
        {
            transform.position = new Vector2(-35.22f, -1.31f);
            sound.SetActive(true);
            sound1.SetActive(false);
            post.SetActive(false);
            theblackpanel.SetActive(true);
            unlock();
            StartCoroutine(white());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bear")  && HP > 0)//&& isattack==false 
        {
       
            HP = HP - 1;
            hurt(1);
            Debug.Log(HP);

            Transform obj = Instantiate(objj, collision.transform.position, new Quaternion());
            obj.gameObject.SetActive(true);
            Destroy(obj.gameObject, 0.5f);
        }
        if (collision.gameObject.CompareTag("boos") && HP > 0)//&& isattack==false 
        {
            place = new Vector2(transform.position.x, transform.position.y);
            transform.position = place;
            HP = HP - 1;
            hurt(1);
            Debug.Log(HP);
            collision.gameObject.SendMessage("unlockmove");  

            Transform obj = Instantiate(objj, collision.transform.position, new Quaternion());
            obj.gameObject.SetActive(true);
            Destroy(obj.gameObject, 0.5f);
            if (HP >= 1)
            {
                sp.material.color = Color.red;
                StartCoroutine(F());
            }

        }
     
    }
  
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("boos"))//&& isattack==false 
        {
            collision.gameObject.SendMessage("lockmove");

            


        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "border2") {
            press2.SetActive(true);
            if (Input.GetKeyDown(KeyCode.T)&&ismiftahready==true)
            {
                newborder.SetActive(false);
                xscript.SendMessage("useit"); 
            }
        }
        
   
        if (collision.tag == "press")
        {
            press.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) )
            {
                if (!ispressed)
                {
                    // E key is pressed for the first time, activate the panel
                    press.gameObject.SetActive(false);
                    xscript.gameObject.SendMessage("posionnotrightnow");
                    sellerpanel.gameObject.SetActive(true);
                    
                    ispressed = true;
                    unlock();
                }
                else
                {
                    // E key is pressed again, deactivate the panel
                    
                    ispressed = false;
                    xscript.gameObject.SendMessage("posioinrightnow");
                  
                    press.gameObject.SetActive(true);
                 
                    sellerpanel.gameObject.SetActive(false);
                    lock1();
                }
                
            }
          
        }
        if (collision.tag == "newpress")
        {
            presst.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.T)&&keynumber>=1)
            {
              
                    // E key is pressed for the first time, activate the panel
                    presst.gameObject.SetActive(true);
                   bahaborder.gameObject.SetActive(false);
                keynumber = keynumber - 1;
                key.text = "" + keynumber;
            }

        }
        if (collision.tag == "chest")
        {
            presschest.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
               
                if (!ispressed)
                {
                    // E key is pressed for the first time, activate the panel
                    presschest.gameObject.SetActive(false);
                    bartool.gameObject.SetActive(true);
                    chestpanel.gameObject.SetActive(true);
                    ispressed = true;
                    unlock();
                }
                else
                {
                    // E key is pressed again, deactivate the panel

                    ispressed = false;

                    presschest.gameObject.SetActive(true);
                    chestpanel.gameObject.SetActive(false);
                    bartool.gameObject.SetActive(false);
                    lock1();
                }

            }
        }
        if(collision.tag == "rocks")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                collision.gameObject.SendMessage("isyou");
                Debug.Log("sended"); 
            }
        }
        if (collision.tag == "chest10")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                if (!ispressed)
                {
                    // E key is pressed for the first time, activate the panel
                    chest2.SetActive(true);
                    ispressed = true;
                    unlock();
                }
                else
                {
                    // E key is pressed again, deactivate the panel

                    ispressed = false;
                    chest2.SetActive(false);
                    lock1();
                }
            }
        }

    }
    
    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.tag == "chest10")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                chest2.SetActive(false);
            }
        }
        if (collision.tag == "border2")
        {
            press2.SetActive(false);
        }
        if (collision.tag == "press")
        {
            press.gameObject.SetActive(false);
        }
        if (collision.tag == "newpress")
        {
            presst.gameObject.SetActive(false);
        }
        if (collision.tag == "chest")
        {
            presschest.SetActive(false);
        }
    }
    IEnumerator A()
    {
        yield return new WaitForSeconds(1);
        //transform.position = new Vector2(-9.71f, 2.47f);
        // unlockmove();
        //  HP = M;
        // hurt(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        StartCoroutine(Aplus());
    }
    IEnumerator Aplus()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("ishurt", false);
    }
    IEnumerator D()
    {

        yield return new WaitForSeconds(0.7f);
        anim.SetBool("ishurt1", false);

    }
 IEnumerator F()
    {
        yield return new WaitForSeconds(0.4f);
        sp.material.color = Color.white;
        
    }
    IEnumerator E()
    {
        yield return new WaitForSeconds(0.3f);
        attackzone1.gameObject.SetActive(false);
        attackzone2.gameObject.SetActive(false);
        attackzone3.gameObject.SetActive(false);
        attackzone4.gameObject.SetActive(false);
        isattack = false;
        canmove = true;
    }
    IEnumerator attackcontrollerr()
    {
        yield return new WaitForSeconds(0.2f);
        isattack = true;
        
    }
    void hurt(int damage)
    {
        
        bar.setHealth(HP);
    }
     void OnMove()
    {
       canmove = false;
    }
   void unlockmove()
    {
        canmove = true;
    }
    IEnumerator RepeatFunction()
    {
        while (canattack ==false && elapsedTime < repeatDuration)
        {
            // Call the function you want to repeat here
            DoSomething();

            // Wait for 1 second
            yield return new WaitForSeconds(0.08f);

            // Update the elapsed time
            elapsedTime ++;
        }

    }

    void DoSomething()
    {
        // Your logic here
        att = att + 4;
        attackcontroller.setattackborder(att);

    }
    public void unlock()
    {
      canmove = false;
        canattack = false;
    }
    public void lock1()
    {
        canmove = true;
        canattack = true;
    }
    public void baha()
    {
        HP = HP - 3;
        hurt(1);
        Debug.Log(HP);

        Transform obj = Instantiate(objj, transform.position, new Quaternion());
        obj.gameObject.SetActive(true);
        Destroy(obj.gameObject, 0.5f);
        if (HP >= 1)
        {
            sp.material.color = Color.red;
            StartCoroutine(F());
        }
    }
    public void ha()
    {
        HP = HP - 3;
        hurt(1);
        Debug.Log(HP);

        Transform obj = Instantiate(objj, transform.position, new Quaternion());
        obj.gameObject.SetActive(true);
        Destroy(obj.gameObject, 0.5f);
        if (HP >= 1)
        {
            sp.material.color = Color.red;
            StartCoroutine(F());
        }
    }
    public void coin()
    {
        score++;
        S.text =""+score;
    }
    public void clicked()
    {
        if (score>=5) {
            keynumber++;
            key.text = "" + keynumber;
            score = score - 5;
            S.text = "" + score;
        }
    }
    public void clickedpotion()
    {
        if (score >= 4)
        {

            script.PickupItem(0); 
          
        }
    }
    public void usepotion()
    {
        StartCoroutine(increase()); 
        Transform obj = Instantiate(useyes, transform.position, new Quaternion());
        obj.gameObject.SetActive(true);
        Destroy(obj.gameObject, 3f);
      
    }
    IEnumerator increase()
    {
        yield return new WaitForSeconds(1.5f); 
        HP = M;
        bar.setMaxhealth(HP);
    }
    public void clickedpotion1()
    {
        if (score >= 2)
        {

            script.PickupItem(1);
        
        }
    }
    public void clickedpotion2()
    {
        if (score >= 2)
        {

            script.PickupItem(2);
        
        }
    }
    public void usepotion1()
    {
        StartCoroutine(increase1());
        Transform obj = Instantiate(useyes, transform.position, new Quaternion());
        obj.gameObject.SetActive(true);
        Destroy(obj.gameObject, 3f);

    }
    IEnumerator increase1()
    {
        yield return new WaitForSeconds(1.5f);
        speed = speed + 200;
        StartCoroutine(ensdincrease1());
    }
    IEnumerator ensdincrease1()
    {
        yield return new WaitForSeconds(15f);
        speed = speed - 200;
    }
    public void scoree()
    {
        supertext.SetActive(true);
        StartCoroutine(BW());
        score = score +2;
        S.text = "" + score;

    }
    public void lockdor()
    {
        candor = true;
    }
    public void posionready()
    {
        posionzone.SetActive(true);
        
    }
    public void posionnotready()
    {
        posionzone.SetActive(false);
        
    }
    public void healthpotion()
    {
        score = score - 4;
        S.text = "" + score;
    }
    public void speedpotion()
    {
        score = score - 2;
        S.text = "" + score;
    }
    public void posionpotion()
    {
        score = score - 2;
        S.text = "" + score;
    }
     IEnumerator BW()
    {
    yield return new WaitForSeconds(1f);
        supertext.SetActive(false); 
    }
    public void sword1ready()
    {
        issword1 = true;
    }
    public void sword1notready()
    {
        issword1 = false;
    }
    public void miftahready()
    {
        ismiftahready = true;
    }
    public void miftahnotready()
    {
        ismiftahready = false;
    }
    IEnumerator white()
    {
        yield return new WaitForSeconds(0.75f);
        theblackpanel.SetActive(false);
        lock1();
        
    }
}


