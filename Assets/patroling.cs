using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class patroling : MonoBehaviour
{
    public Vector3 centrepoint;
    public float radius;
    float changed=5f;
    [SerializeField]Vector3 threaldestinationpoint;
    Vector3 middestination;
    NavMeshAgent mynavmeshagent;
    [SerializeField] bool checking;
    bool keepwalking = true;
    [SerializeField] float remainingdistance;
    navmeshstoppingvalue mynavmeshstoppingvalue;
    public bool getkeepwalking
    {
        set { keepwalking = value; }
        get { return keepwalking; }
    }    // Start is called before the first frame update
    void Start()
    {
        mynavmeshagent = GetComponent<NavMeshAgent>();
        mynavmeshstoppingvalue = GetComponent<navmeshstoppingvalue>();
        centrepoint = transform.position;
        threaldestinationpoint = centrepoint;
    }

    // Update is called once per frame
    void Update()
    {

        ///call by refeernce
        /* if(changingvalues(out changed))
         {
             Debug.Log("the changed "+changed);
         }
     }
     bool changingvalues(out float value)
     {
         value = 6f;
         return true;
     }*/
        ///////////////////////////////////////////////////////////////
        ///
        //still patrling causing some problems
        if (keepwalking /*&& mynavmeshagent*/)
        {
            if (mynavmeshagent.remainingDistance <= mynavmeshagent.stoppingDistance)    
            {
               

                if (randompoint(centrepoint, radius, out middestination))
                {
                    
                    threaldestinationpoint = middestination;
                    transform.LookAt(new Vector3(threaldestinationpoint.x, centrepoint.y, threaldestinationpoint.z));
                }
                else
                {
                   
                }
            }
         
            remainingdistance = mynavmeshagent.remainingDistance;
            mynavmeshagent.SetDestination(new Vector3(threaldestinationpoint.x, centrepoint.y, threaldestinationpoint.z));
            
        }
        //////////////////////////////////////////////////////////////////
        stoppingpseed();

    }

    public bool randompoint(Vector3 centre, float range, out Vector3 destinationpoint)
    {
        Vector3 thrandompoint = centre + Random.insideUnitSphere * range;
        NavMeshHit hit;

        //the out hit is very important it finds that random point inside the rage
        if (NavMesh.SamplePosition(thrandompoint, out hit, 1f, NavMesh.AllAreas))
        {
            
            destinationpoint = hit.position;
            //checking is just for my reference
            checking = true;
            return true;
        }
        //the below would only run if the destination does not falss in range
        destinationpoint = Vector3.zero;
        /*destinationpoint = Vector3.zero;
       */
        checking = false;
        return false;
    }
    public void stoppingpseed()
    {
        if(!keepwalking)
        {
            /*Debug.Log("here");*/
            //here we need to change
            /*mynavmeshagent.speed = 5f;
            mynavmeshagent.stoppingDistance = 6f;*/
            mynavmeshstoppingvalue.setstoppingdistance();
        }
    }
}
