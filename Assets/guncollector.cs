using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guncollector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //should be attached to capsule
    private void OnCollisionEnter(Collision collision)
    {
        /* Debug.Log("the collider name " + collision.collider.name);*/


        //chechk if the gunlimit is zero

        if (collision.collider.gameObject.tag == "thegun")
        {
            GameObject thetargetgun = collision.collider.gameObject;
           /* Debug.Log("thetarget gun "+ thetargetgun);*/
            if (collision.collider.gameObject.transform.parent==null)
            {
                Destroy(collision.collider.gameObject);
            }
        }



        /*if (collision.collider.name == "M9_prefab")
        {
            Debug.Log("the collider name " + collision.collider.name);
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.name == "Ak-47")
        {
            Debug.Log("the collider name " + collision.collider.name);
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.name == "shotgun")
        {
            Debug.Log("the collider name " + collision.collider.name);
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.name == "AWP")
        {
            Debug.Log("the collider name " + collision.collider.name);
            Destroy(collision.collider.gameObject);
        }*/
    }
}
