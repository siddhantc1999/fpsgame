using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycount : MonoBehaviour
{
    int myenemycount;
    [SerializeField] GameObject enemycounttext;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        myenemycount = transform.childCount;
        Debug.Log("the count "+myenemycount);
        displaycount();
    }

   

    // Update is called once per frame
    void Update()
    {
        myenemycount = transform.childCount;
        displaycount();
        /*GetComponent<TextMeshProUGUI>().text = "Ammo:" + initialammo.ToString();*/
    }
    public void displaycount()
    {
        enemycounttext.GetComponent<TMPro.TextMeshProUGUI>().text = "ENEMIES:" + myenemycount.ToString();
    }

}
