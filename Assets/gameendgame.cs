using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameendgame : MonoBehaviour
{
    // Start is called before the first frame update
    int heath;
    armortext myarmortext;
    public int gethealth
    {
        set { heath = value; }
    }
    void Start()
    {
        myarmortext = FindObjectOfType<armortext>();
    }

    // Update is called once per frame
    void Update()
    {
        if(myarmortext.gethealth<=0)
        {
            Debug.Log("here less than 0");
        }
    }
}
