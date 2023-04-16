using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemyshoot : MonoBehaviour
{
    Animator myanimator;
    AnimatorClipInfo[] myanimatorclipinfo;
    AnimatorClipInfo[] myanimatorclipinfo2;
    bool ak47spawnerfire = true;
    [SerializeField] bool rapidpplay = true;
    private AudioSource myaudiosource;
    [SerializeField] AudioClip clip1;
    bool rapidshoot = true;
    public GameObject[] fireobjects;
    [SerializeField] Transform ak47firespawn;
    [SerializeField] GameObject metalimpact;
    [SerializeField] float ak47range;
    playerhealth myplayerhealth;
    [SerializeField] bool isak47=true;
    [SerializeField] float timer=0;
    [SerializeField] bool fireonoff = true;
    [SerializeField] float randomrange;
    // Start is called before the first frame update
    void Start()
    {
        myaudiosource = GetComponent<AudioSource>();
        myanimator = GetComponentInParent<Animator>();
        myplayerhealth = FindObjectOfType<playerhealth>();

    }

    // Update is called once per frame
    void Update()
    {
        myanimatorclipinfo = myanimator.GetCurrentAnimatorClipInfo(1);
        myanimatorclipinfo2 = myanimator.GetCurrentAnimatorClipInfo(2);
        string currentanimation = myanimatorclipinfo[0].clip.name;
        string currentanimation2 = myanimatorclipinfo2[0].clip.name;
        //for first provoke i ant to mae it faster
        Debug.DrawRay(transform.position, transform.forward * 7f, Color.red);




        //i have to use a timer


        if (currentanimation== "enemyshoot" && myanimator.GetLayerWeight(1)==1 /*&& isak47==true*/)
        {
            timer += Time.deltaTime;
            randomrange = Random.Range(1,3);
            if (timer <= randomrange && fireonoff)
            {
                ////////////////////////////////////////////////
                if (ak47spawnerfire == true)
                {
                    ak47spawnerfire = false;
                    StartCoroutine(rapidfireexplosion());

                }
                //the bwlow code is very important
                if (rapidpplay == true)
                {
                    /*Debug.Log("in rapi play");*/
                    rapidpplay = false;
                    myaudiosource.clip = clip1;
                    myaudiosource.loop = true;
                    myaudiosource.Play();
                }
                if (rapidshoot == true)
                {
                    rapidshoot = false;
                    StartCoroutine(machinegunwall());
                }



            }
            else if (timer <= randomrange && fireonoff==false)
            {
                myaudiosource.Stop();
                myaudiosource.loop = false;
                /* myaudiosource.Stop();*/
                rapidpplay = true;
                /*if (timer >= randomrange)
                {
                    timer = 0f;
                    fireonoff = true;
                }*/
               
            }

            if (timer >= randomrange)
            {
                if (fireonoff)
                {
                    timer = 0f;
                    fireonoff = false;
                }
                else
                 if(!fireonoff)
                {
                    timer = 0f;
                    fireonoff = true;
                }
            }

        }
        else
        {
       
            myaudiosource.Stop();
            myaudiosource.loop = false;
           
            rapidpplay = true;
            fireonoff = true;
        }
     
        if (currentanimation2 == "death")
        {
            Debug.Log("here");
            this.enabled = false;
        }


    }

  /*  IEnumerator ak47delay()
    {
        yield return new WaitForSeconds(0.5f);
        isak47 = true;
    }*/

    IEnumerator rapidfireexplosion()
    {
        yield return new WaitForSeconds(0.05f);
        ak47spawnerfire = true;
        int randomnumer = UnityEngine.Random.Range(0, fireobjects.Length - 1);
        /* Debug.Log("the randomnumber "+randomnumer);*/
        Instantiate(fireobjects[randomnumer], ak47firespawn.position, ak47firespawn.rotation);

    }
    IEnumerator machinegunwall()
    {
        //impact wall this function need to change for machine gun , pistol and 

        yield return new WaitForSeconds(0.2f);
        if (Physics.Raycast(transform.position,transform.forward, out RaycastHit hit, ak47range))
        {
            Debug.Log("the ak47range "+ ak47range);
            if (hit.transform.tag == "hitsurface")
            {
               /* Instantiate(metalimpact, hit.point, Quaternion.LookRotation(hit.normal));*/
            }
            if (hit.transform.name == "Capsule")
            {
                Debug.Log("in capsule");
                myplayerhealth.playerharm(1);
            }
            /*if(hit.collider.name== "PlayerCapsule")
            {
                Debug.Log("playercapsule");
            }*/
        }
        rapidshoot = true;
    }
    
}
