using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerhealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameObject blood;
    [SerializeField] GameObject bloodbackground;
    [SerializeField] Canvas mycanvas;
    bool activeblood;
   /* [SerializeField] GameObject playerdeadgameobject;*/
    public int gethealth
    {
        get { return health; }
        set { health = value; }
    }
    // Start is called before the first frame update
    private void Awake()
    {
        FindObjectOfType<armortext>().gethealth = health;
    }
    void Start()
    {
        /*FindObjectOfType<armortext>().gethealth*/
        blood.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       /* if()*/
    }
    public void playerharm(int harmvalue)
    {
        if (health>=0)
        {
            health -= harmvalue;
            FindObjectOfType<armortext>().gethealth = FindObjectOfType<armortext>().gethealth - harmvalue;
            GameObject bloodobject = Instantiate(blood);
            GameObject redobject = Instantiate(bloodbackground);
            bloodobject.SetActive(true);
            redobject.SetActive(true);
            bloodobject.transform.parent = mycanvas.transform;
            redobject.transform.parent = mycanvas.transform;
            bloodobject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
            redobject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 0f);
            if (health <= 0)
            {
                /* playerdeadgameobject.GetComponent<>();*/
                GetComponentInParent<Animator>().Play("playerdead");
                /*Get*/
            }
        }
    }
}
