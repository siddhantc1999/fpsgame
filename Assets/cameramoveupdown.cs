using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramoveupdown : MonoBehaviour
{
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*timer += Time.deltaTime;*/
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            /* Debug.Log("here"+ Mathf.Sin(Time.time) * Time.deltaTime);
             transform.position = transform.position + new Vector3(transform.position.x, Mathf.Sin(Time.time) * Time.deltaTime, transform.position.z);*/

            GetComponent<Animator>().Play("camerupdown");
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
           
            GetComponent<Animator>().Play("statcam");
          
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            GetComponent<Animator>().Play("camerupdown");
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            GetComponent<Animator>().Play("statcam");
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().Play("camerupdown");
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().Play("statcam");
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().Play("camerupdown");

        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().Play("statcam");
        }
    }

    public void moveupdown()
    {
     
       /* transform*/
    }
}
