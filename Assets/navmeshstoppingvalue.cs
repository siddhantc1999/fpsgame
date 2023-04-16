using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navmeshstoppingvalue : MonoBehaviour
{
    NavMeshAgent mynavmeshagent;
    [SerializeField] float speed;
    [SerializeField] float stoppingDistance;
    // Start is called before the first frame update
    void Start()
    {
        mynavmeshagent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void  setstoppingdistance()
    {
        mynavmeshagent.speed = speed;  //5f
        mynavmeshagent.stoppingDistance = stoppingDistance;
    }
}
