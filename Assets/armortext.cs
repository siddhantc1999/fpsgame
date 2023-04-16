using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class armortext : MonoBehaviour
{
    int mainhealth;
    public int gethealth
    {
        get { return mainhealth; }
        set{ mainhealth = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Armour:" + mainhealth.ToString();
    }
    
}
