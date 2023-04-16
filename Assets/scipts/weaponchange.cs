using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponchange : MonoBehaviour
{
    float mousey = 0;
    public GameObject[] allguns;
    [SerializeField]int mousevalue = 0;
    screenpointray myscreenpointray;
    // Start is called before the first frame update
    void Start()
    {
        mousevalue = 0;
        myscreenpointray = FindObjectOfType<screenpointray>();
    }

    // Update is called once per frame
    void Update()
    {
       
       if(mousevalue>=0 && mousevalue<allguns.Length)
        {
           
            mousevalue += (int)Input.mouseScrollDelta.y;
            turnonoffguns(mousevalue);

        }
       if(mousevalue>=allguns.Length)
        {
            mousevalue = 0;
            turnonoffguns(mousevalue);
        }
       if(mousevalue<0)
        {
            mousevalue = 0;
            turnonoffguns(mousevalue);
        }
    }
    void turnonoffguns(int mousevalue)
    {
        for(int i=0;i<allguns.Length;i++)
        {
            if(mousevalue==i)
            {
                myscreenpointray.setweaponid = mousevalue;
                allguns[i].SetActive(true);
            }
            else
            {
                allguns[i].SetActive(false);
            }
        }

    }
    
}
