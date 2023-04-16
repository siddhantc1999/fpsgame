using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ammotext : MonoBehaviour
{
    [SerializeField] float initialammo;
    float getammo;
    public float setammo
    {
        set { initialammo = value; }
        get { return getammo; }
    }
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Ammo:" + initialammo.ToString();
        getammo = initialammo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
