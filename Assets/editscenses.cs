using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class editscenses : MonoBehaviour
{
    public GameObject first;
    public GameObject first1;
    public GameObject first2;
    public GameObject first3;
    public GameObject first4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void scene2()
    {
        first.SetActive(false);
        first1.SetActive(false);
        first2.SetActive(false);
        first3.SetActive(false);
        first4.SetActive(false);
        StartCoroutine(Startjoll()); 
         
    }
    IEnumerator Startjoll()
    {
        yield return new WaitForSeconds(1); 
        SceneManager.LoadScene("joll");
    }
    public void quitgame() {
        Application.Quit();
    }
}
