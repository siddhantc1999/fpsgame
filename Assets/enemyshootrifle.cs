using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshootrifle : MonoBehaviour
{
    Animator myanimator;
    AnimatorClipInfo[] myanimatorclipinfo;
    AnimatorClipInfo[] myanimatorclipinfo2;
    private AudioSource myaudiosource;
    [SerializeField] AudioClip snipersound;

  /*  [SerializeField] Transform ak47firespawn;*/
 /*   [SerializeField] GameObject metalimpact;*/



    /*[SerializeField] GameObject shotgunexplosion;
    [SerializeField] GameObject shotgunfireobject;*/
    [SerializeField] Transform shotgunfirespawn;
    [SerializeField] Transform ray;
    bool sniperwait = true;
    [SerializeField] float sniperrange;
    playerhealth myplayerhealth;
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
        Debug.DrawRay(ray.position, ray.forward * 100f, Color.red);
       

        if (currentanimation == "riflegunenemyshoot" && myanimator.GetLayerWeight(1) == 1 && sniperwait == true)
        {




            myaudiosource.clip = snipersound;
            myaudiosource.Play();
            StartCoroutine(sniperwall());
            if (sniperwait == true)
            {
                sniperwait = false;
                StartCoroutine(sniperdelay());
            }
        }
        if (currentanimation2 == "death")
        {
           /* Debug.Log("here");*/
            this.enabled = false;
        }




        //////////////////////////////////////////////////
        /*Instantiate(shotgunfireobject, shotgunfirespawn.position, shotgunfirespawn.rotation);

        myaudiosource.clip = shotgunclip;
        myaudiosource.Play();
        StartCoroutine(shotgunwall());
        //delay in shotgun 
        if (shootshotgun == true)
        {
            shootshotgun = false;
            StartCoroutine(shotgundelay());
        }
*/
        /////////////////////////////////////////



    }
    IEnumerator sniperdelay()
    {
        yield return new WaitForSeconds(2f);
        sniperwait = true;
    }


   /* IEnumerator shotgundelay()
    {

        yield return new WaitForSeconds(1.5f);
        shootshotgun = true;
        shootshotgun =
        }*/
    IEnumerator sniperwall()
    {
        yield return new WaitForSeconds(0.2f);
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 12f))
        {
            /*if (hit.transform.tag == "hitsurface")
            {
                Instantiate(shotgunexplosion, hit.point, Quaternion.LookRotation(hit.normal));
            }*/
            if (hit.transform.name == "Capsule")
            {
                Debug.Log("in capsule");
                myplayerhealth.playerharm(1);
            }
        }
    }


}

