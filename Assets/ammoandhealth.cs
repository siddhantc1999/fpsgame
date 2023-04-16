using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoandhealth : MonoBehaviour
{
    /*GameObject[] ammos;*/
    /*[SerializeField] GameObject gunparent;*/
    screenpointray myscreenpointray;
   /* int i=0;*/
    // Start is called before the first frame update
    void Start()
    {
        myscreenpointray = FindObjectOfType<screenpointray>();
    }

    // Update is called once per frame
    void Update()
    {
        /* Debug.Log("the child count "+transform.childCount);*//*
        for(int i=0;i<transform.childCount+1;i++)
         {

             if(myscreenpointray.setweaponid< transform.childCount && i<transform.childCount)
             {
                 if(i== myscreenpointray.setweaponid)
                 {
                     transform.GetChild(i).gameObject.SetActive(true);
                 }
                 else
                 {
                     transform.GetChild(i).gameObject.SetActive(false);
                 }
             }
             else 
             {
                 *//*transform.GetChild(i).gameObject.SetActive(false);*//*
             }

         }*/
        if (myscreenpointray.setweaponid < transform.childCount /*&& i < transform.childCount*/)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (i == myscreenpointray.setweaponid)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
                else
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }
        else
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
