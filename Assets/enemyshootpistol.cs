using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshootpistol : MonoBehaviour
{
    Animator myanimator;
    AnimatorClipInfo[] myanimatorclipinfo;
    AnimatorClipInfo[] myanimatorclipinfo2;
    private AudioSource myaudiosource;
    [SerializeField] AudioClip pistolclip;

    /*  [SerializeField] Transform ak47firespawn;*/
    /*   [SerializeField] GameObject metalimpact;*/

    [SerializeField] float pistolrange;

   
    [SerializeField] GameObject pistolfireobject;
    [SerializeField] Transform pistolspawn;
    [SerializeField] Transform ray;
    bool ispistol = true;
    playerhealth myplayerhealth;
    // Start is called before the first frame update
    void Start()
    {
        myaudiosource = GetComponent<AudioSource>();
        myanimator = GetComponentInParent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        myanimatorclipinfo = myanimator.GetCurrentAnimatorClipInfo(1);
        myanimatorclipinfo2 = myanimator.GetCurrentAnimatorClipInfo(2);
        string currentanimation = myanimatorclipinfo[0].clip.name;
        string currentanimation2 = myanimatorclipinfo2[0].clip.name;
        myplayerhealth = FindObjectOfType<playerhealth>();

       /* Debug.DrawRay(ray.position, ray.forward * 100f, Color.red);*/
        /*   Debug.Log("the positon " + transform.localPosition); ;*/

        if (currentanimation == "Pistolshoot" && myanimator.GetLayerWeight(1) == 1 && ispistol == true)
        {

            //////////////////////////////////////////////////
            Instantiate(pistolfireobject, pistolspawn.position, pistolspawn.rotation);

            myaudiosource.clip = pistolclip;
            myaudiosource.Play();
            StartCoroutine(shotgunwall());
            //delay in shotgun 
            if (ispistol == true)
            {
                ispistol = false;
                StartCoroutine(pistoldelay());
            }




        }
       /* Debug.Log("the current animation 2"+ currentanimation2);*/
        if(currentanimation2 == "death")
        {
         /*   Debug.Log("here");*/
            this.enabled = false;
        }
    } 

        IEnumerator pistoldelay()
        {

            yield return new WaitForSeconds(1f);
            ispistol = true;
            /* shootshotgun=*/
        }
        IEnumerator shotgunwall()
        {
            yield return new WaitForSeconds(0.2f);
            if (Physics.Raycast(ray.transform.position, ray.transform.forward, out RaycastHit hit, pistolrange))
            {
            /*Debug.Log("the name of the hit"+hit.transform.name);*/
            if (hit.transform.name == "Capsule")
            {
                myplayerhealth.playerharm(1);
            }
            /* if (hit.transform.tag == "hitsurface")
             {
                *//* Instantiate(shotgunexplosion, hit.point, Quaternion.LookRotation(hit.normal));*//*
             }*/
        }
        }
        


    
    private void OnCollisionEnter(Collision collision)
    {
       /* if(collision.collider.name== "Capsule")
        {
           
            Destroy(collision.collider.gameObject);
        }*/
    }
}
