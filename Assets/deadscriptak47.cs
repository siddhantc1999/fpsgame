using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class deadscriptak47 : MonoBehaviour
{
    Animator myanimator;
    public int gunlimit=2;
    [SerializeField] GameObject gun;
    AnimatorClipInfo[] myanimatorclipinfo;
    NavMeshAgent mynavmeshagent;
  /*  [SerializeField] GameObject dropgunrigidbodyoff;*/
    public int getgunlimit
    {
        set { gunlimit = value; }
        get { return gunlimit; }
    }



    //should be attached to enemysoldier



    // Start is called before the first frame update
    void Start()
    {
        myanimator = GetComponent<Animator>();
        myanimatorclipinfo = myanimator.GetCurrentAnimatorClipInfo(0);
        mynavmeshagent = GetComponent<NavMeshAgent>();


    }

    // Update is called once per frame
    void Update()
    {
        myanimatorclipinfo = myanimator.GetCurrentAnimatorClipInfo(2);
        string currentanimation = myanimatorclipinfo[0].clip.name;
     
        /*  Debug.Log("the current animation "+currentanimation);*/
        if (gunlimit <= 0)
        {
            if (currentanimation != "death" && myanimator.GetLayerWeight(2) != 1)
            {

                myanimator.SetLayerWeight(2, 1);

                myanimator.SetTrigger("isdead");
                GetComponent<enemyai>().enabled = false;
                GetComponent<patroling>().enabled = false;
                mynavmeshagent.enabled = false;
                gun.transform.parent = null;
                GetComponent<CapsuleCollider>().enabled = false;
                gun.GetComponent<Rigidbody>().useGravity = true;
                gun.GetComponent<Rigidbody>().isKinematic = false;
                /* gun.GetComponent<enemyshootpistol>().enabled = false;*/
                gun.GetComponent<AudioSource>().enabled = false;

            }
        }
    }
   /* private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("here in collision");

    }*/

}
