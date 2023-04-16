using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootjerk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*  public void camjerk(float h, float v)
      {

         *//* float h = Random.insideUnitSphere.x;*//*
          transform.position = new Vector3(h * Time.deltaTime, v * Time.deltaTime, 0f);
      }
      public void originalpos()
      {
          transform.position = new Vector3(0f, 0f, 0f);
      }*/
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision"+collision.collider.name);
    }
}
