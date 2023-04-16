using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.AI;
public class screenpointray : MonoBehaviour
{
    [SerializeField] GameObject metalimpact;
    CinemachineVirtualCamera vcam;
      public GameObject[] fireobjects;
    [SerializeField] GameObject virtualcam;
    [SerializeField] GameObject blood;
    /* [SerializeField] GameObject fireobject1;
     [SerializeField] GameObject fireobject2;
     [SerializeField] GameObject fireobject3;*/




    [SerializeField] Transform ak47firespawn;
    /*[SerializeField] Transform sniperfirespawn;*/
    [SerializeField] Transform deserteaglefirespawn;
    [SerializeField] Transform shotgunfirespawn;
    [SerializeField] GameObject shotgunfireobject;
    [SerializeField] GameObject shotgunexplosion;
    [SerializeField] GameObject scope;
    [SerializeField] GameObject sniper;
    bool sniperwait = true;
    [SerializeField] GameObject knifepoint;
    [SerializeField] float kniferange;

    [SerializeField] GameObject crosshair;

    // Start is called before the first frame update
    [SerializeField] [Range(1, 5)] float weaponid = 1;
    [SerializeField] AudioClip clip1;
    [SerializeField] AudioClip clip2;
    [SerializeField] AudioClip clip3;
    private AudioSource myaudiosource;
    bool rapidpplay = true;
    bool rapidshoot = true;


    bool ak47spawnerfire = true;
    [SerializeField] GameObject knifeanimation;
    [SerializeField] GameObject sniperanimation;
    bool knifekilling=true;

    [SerializeField] GameObject ak47;
    Animator ak47amination;
    [SerializeField] GameObject deserteagle;
    Animator deserteagleamination;
    [SerializeField] GameObject shotgun;
    Animator shotgunanimation;


    bool sniperapidplay = true;
    [SerializeField] AudioClip snipersound;
    [SerializeField] AudioClip knifesound;
    /* [SerializeField] Camera fpcamera;*/
    shootjerk myshootjerk;
    enemyai myenemyai;
    patroling mypatroling;
    deadscript mydeadscript;
    deadscriptak47 mydeadscript47;
    bool pistoltrue=true;

   /* [SerializeField] float thresholddesitanceafterwhichitshouldrunifhit;*/
    public float setweaponid
    {
        set { weaponid = value; }
        get { return weaponid; }
    }



    bool shootshotgun = true;
    Animator myanimator;


    void Start()
    {
        myaudiosource = GetComponent<AudioSource>();
        myanimator = sniperanimation.GetComponentInChildren<Animator>();
        vcam = virtualcam.GetComponent<CinemachineVirtualCamera>();
        ak47amination = ak47.GetComponent<Animator>();
        deserteagleamination = deserteagle.GetComponent<Animator>();
        shotgunanimation = shotgun.GetComponent<Animator>();
        myshootjerk = FindObjectOfType<shootjerk>();
        myenemyai = FindObjectOfType<enemyai>();
        mypatroling = FindObjectOfType<patroling>();
        mydeadscript = FindObjectOfType<deadscript>();
        mydeadscript47 = FindObjectOfType<deadscriptak47>();
        /*if(mypatroling==null)
        {
            Debug.Log("null");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        /////////////////////////////////////////
        ///we have t change the range of shotgun ak47 pistol and sniper



       /* Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 5f, Color.red);*/



        if (weaponid == 0)
        {
            crosshair.SetActive(true);
            if (Input.GetMouseButtonDown(1) && pistoltrue /*&& weaponid==1*/)
            {
                deserteagleamination.SetTrigger("desertfire");
                Instantiate(fireobjects[UnityEngine.Random.Range(0, fireobjects.Length - 1)], deserteaglefirespawn.position, deserteaglefirespawn.rotation);
                myaudiosource.clip = clip1;
                myaudiosource.Play();
               /* myshootjerk.camjerk(0.15f, 0.15f);*/
                /* myaudiosource.loop = true;*/
                pistolwall();
                if (pistoltrue == true)
                {
                    pistoltrue = false;
                    StartCoroutine(pistolgundelay());
                }
            }
           /* if(Input.GetMouseButtonUp(1))
            {
                myshootjerk.camjerk(0.15f, 0.15f);
            }*/
          /*  if()*/

        }
        else if (weaponid == 1)
        {
            crosshair.SetActive(true);
            if (Input.GetMouseButton(1))
            {
                ak47amination.SetTrigger("akfire");
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
                    myaudiosource.clip = clip2;
                    myaudiosource.loop = true;
                    myaudiosource.Play();
                }
                if (rapidshoot == true)
                {
                    rapidshoot = false;
                    StartCoroutine(machinegunwall());
                }
            }
            if (Input.GetMouseButtonUp(1))
            {
                myaudiosource.Stop();
                myaudiosource.loop = false;
                /* myaudiosource.Stop();*/
                rapidpplay = true; ;


            }
            //it draws a ray from camera point to whree mouse in in game window lies,use 2d window rather than 3d window

            /*  if (Physics.Raycast(ray, out RaycastHit myraycasthit, 100f)) 
              {
                  Debug.Log("the name of hitobject "+myraycasthit.transform.name);
              }*/
        }
        else
        if (weaponid == 2)
        {
            crosshair.SetActive(true);
            if (Input.GetMouseButtonDown(1) && shootshotgun == true)
            {
                shotgunanimation.SetTrigger("shotgunfiring");
                Instantiate(shotgunfireobject, shotgunfirespawn.position, shotgunfirespawn.rotation);

                myaudiosource.clip = clip3;
                myaudiosource.Play();
                StartCoroutine(shotgunwall());
                //delay in shotgun 
                if (shootshotgun == true)
                {
                    shootshotgun = false;
                    StartCoroutine(shotgundelay());
                }


            }
        }
        else
        if (weaponid == 3)
        {
            crosshair.SetActive(false);
            if (Input.GetMouseButton(1))
            {
                /* Debug.Log("here in getmousebutton ");*/
                myanimator.SetBool("camzoom", true);
                
                StartCoroutine(scopeandweapon());
                if (Input.GetMouseButtonDown(0) && sniperwait==true)
                {
                    myaudiosource.clip = snipersound;
                    myaudiosource.Play();
                    if (sniper.active == false)
                    {
                        
                        StartCoroutine(sniperwall());
                        if (sniperwait == true)
                        {
                            sniperwait = false;
                            StartCoroutine(sniperdelay());
                        }
                    }
                }

            }
            else
            if (Input.GetMouseButtonUp(1))
            {
               
                StartCoroutine(reppear());
             
            }
        }
        else
        if (weaponid == 4)
        {
            Debug.DrawRay(knifepoint.transform.position, knifepoint.transform.forward,Color.red ,10f);
            crosshair.SetActive(false);

            if (Input.GetMouseButtonDown(1) && knifekilling==true)
            {
                if (Physics.Raycast(knifepoint.transform.position, knifepoint.transform.forward, out RaycastHit hit, kniferange))
                {
                    if (hit.transform.name == "enemysoldierpistol")
                    {
                        GameObject particlesystem = Instantiate(blood, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.LookRotation(hit.normal), hit.transform);
                        hit.collider.gameObject.GetComponent<deadscript>().getgunlimit = 0;
                    }
                }

                knifekilling = false;
                StartCoroutine(knifekill());
               
              
            }
        }
        }

    IEnumerator pistolgundelay()
    {
        yield return new WaitForSeconds(0.5f);
        pistoltrue = true;
    }

    IEnumerator rapidfireexplosion()
    {
        yield return new WaitForSeconds(0.05f);
        ak47spawnerfire = true;
        int randomnumer = UnityEngine.Random.Range(0,fireobjects.Length-1);
       /* Debug.Log("the randomnumber "+randomnumer);*/
        Instantiate(fireobjects[randomnumer], ak47firespawn.position, ak47firespawn.rotation);
        
    }

    IEnumerator knifekill()
    {
        knifeanimation.GetComponentInChildren<Animator>().SetTrigger("kill");
        
        myaudiosource.clip = knifesound;
        myaudiosource.Play();
        yield return new WaitForSeconds(0.75f);
        knifekilling = true;

    }

    IEnumerator reppear()
        {
            yield return new WaitForSeconds(0.3f);
        
        myanimator.SetBool("camzoom", false);
        vcam.m_Lens.FieldOfView = 40f;
        sniper.SetActive(true);

            scope.SetActive(false);
           

        }
        IEnumerator scopeandweapon()
        {

            yield return new WaitForSeconds(0.3f);
        vcam.m_Lens.FieldOfView = 20f;
        scope.SetActive(true);
      
            //CINEMACHINE VIRTUAL CAMERA FOV CHANGE 
            
            sniper.SetActive(false);


        }

    IEnumerator sniperdelay()
    {
        yield return new WaitForSeconds(0.5f);
        sniperwait = true;
    }
         void pistolwall()
        {
        //impact wall this function need to change for machine gun , pistol and 

        /*yield return new WaitForSeconds(0.1f);*/
                
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 7f))
            {
            Debug.Log("the pistol "+hit.collider.name);
            if (hit.collider.tag == "enemyobjects")
            {
                hit.collider.gameObject.GetComponent<deadscript>().getgunlimit = hit.collider.gameObject.GetComponent<deadscript>().getgunlimit - 1;
                
               GameObject particlesystem = Instantiate(blood,new Vector3(hit.point.x,hit.point.y,hit.point.z),Quaternion.LookRotation(hit.normal),hit.transform);

                
                /*particlesystem.transform.parent = GameObject.Find("bloodshed").transform;*/
               /* particlesystem.transform.parent = hit.transform;*/
                float distance=Vector3.Distance(transform.position,hit.transform.position);
               /* Debug.Log("the enemeyobjcts "+ hit.collider.gameObject.GetComponent<enemyai>().getthresholddesitanceafterwhichitshouldrunifhit);*/
                if(distance<= hit.collider.gameObject.GetComponent<enemyai>().getthresholddesitanceafterwhichitshouldrunifhit && distance>=hit.collider.gameObject.GetComponent<enemyai>().getchasethreshold)   //we have to change here in thresholdrunifhit
                {
                    
                    myenemyai.isshoot();
                    mypatroling.getkeepwalking = false;

                    ///is provoked we have to change here
                }
            }
            if (hit.transform.tag == "hitsurface")
                {
               
                    Instantiate(metalimpact, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
            /* rapidshoot = true;*/
        }

        IEnumerator machinegunwall()
        {
            //impact wall this function need to change for machine gun , pistol and 

            yield return new WaitForSeconds(0.1f);
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 7f))
            {
            if (hit.collider.tag == "enemyobjects")
            {
                GameObject particlesystem = Instantiate(blood, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.LookRotation(hit.normal), hit.transform);
                ///here we have to change the ak47harmlimit
                hit.collider.gameObject.GetComponent<deadscript>().getgunlimit = hit.collider.gameObject.GetComponent<deadscript>().getgunlimit - 1;


                float distance = Vector3.Distance(transform.position, hit.transform.position);
                if (distance <= hit.collider.gameObject.GetComponent<enemyai>().getthresholddesitanceafterwhichitshouldrunifhit && distance >= hit.collider.gameObject.GetComponent<enemyai>().getchasethreshold)
                {
                    myenemyai.isshoot();
                    mypatroling.getkeepwalking = false;

                    ///is provoked we have to change here
                }
            }

            if (hit.transform.tag == "hitsurface")
                {
                    Instantiate(metalimpact, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
            rapidshoot = true;
        }
        IEnumerator shotgunwall()
        {
            yield return new WaitForSeconds(0.2f);
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 9f))
            {
            if (hit.collider.tag == "enemyobjects")
            {
                GameObject particlesystem = Instantiate(blood, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.LookRotation(hit.normal), hit.transform);
                ///here we have to change the ak47harmlimit
                hit.collider.gameObject.GetComponent<deadscript>().getgunlimit = hit.collider.gameObject.GetComponent<deadscript>().getgunlimit - 1;

                float distance = Vector3.Distance(transform.position, hit.transform.position);
                if (distance <= hit.collider.gameObject.GetComponent<enemyai>().getthresholddesitanceafterwhichitshouldrunifhit && distance >= hit.collider.gameObject.GetComponent<enemyai>().getchasethreshold)
                {
                    myenemyai.isshoot();
                    mypatroling.getkeepwalking = false;

                    ///is provoked we have to change here
                }
            }
            if (hit.transform.tag == "hitsurface")
                {
                    Instantiate(shotgunexplosion, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
        }
    IEnumerator shotgundelay()
    {

        yield return new WaitForSeconds(1.5f);
        shootshotgun = true;
        /* shootshotgun=*/
    }
    IEnumerator sniperwall()
        {
            yield return new WaitForSeconds(0.2f);
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 12f))
            {
            if (hit.collider.tag == "enemyobjects")
            {
                GameObject particlesystem = Instantiate(blood, new Vector3(hit.point.x, hit.point.y, hit.point.z), Quaternion.LookRotation(hit.normal), hit.transform);
                ///here we have to change the ak47harmlimit
                hit.collider.gameObject.GetComponent<deadscript>().getgunlimit = hit.collider.gameObject.GetComponent<deadscript>().getgunlimit - 1;

                float distance = Vector3.Distance(transform.position, hit.transform.position);
                if (distance <= hit.collider.gameObject.GetComponent<enemyai>().getthresholddesitanceafterwhichitshouldrunifhit && distance >= hit.collider.gameObject.GetComponent<enemyai>().getchasethreshold)                //here we havd to change
                {
                    myenemyai.isshoot();
                    mypatroling.getkeepwalking = false;

                    ///is provoked we have to change here
                }
            }
            if (hit.transform.tag == "hitsurface")
                {
                //change here
               
                Instantiate(metalimpact, hit.point, Quaternion.LookRotation(hit.normal));
                }
            }
        }
    /* IEnumerator shotgundelay()
     {

         yield return new WaitForSeconds(1.5f);
         shootshotgun = true;
         *//* shootshotgun=*//*
     }*/
    

}

