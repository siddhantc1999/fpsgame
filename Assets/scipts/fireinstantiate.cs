using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireinstantiate : MonoBehaviour
{
    [SerializeField] GameObject fireobject;
    [SerializeField] Transform firespawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
       /* if(Input.GetMouseButtonDown(1))
        {

            Instantiate(fireobject,firespawn.position,firespawn.rotation);

        }*/
    }
}
