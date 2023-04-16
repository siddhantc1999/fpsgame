using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] int i=0; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator changingno()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("the i value "+i++);
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        Debug.Log("the name of the collier"+collision.collider.gameObject.name);
    }
    /*private void OnCollisionEnter(Collision collision)
{
   Debug.Log("the collider name "+collision.collider.name);
}*/
}
