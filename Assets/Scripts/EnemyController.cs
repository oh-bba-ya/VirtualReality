using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent nv;
    private Animator anim;
    private Transform monsterTr;
    private Transform targetTr;
    

    void Start()
    {
        nv = this.GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        targetTr = GameObject.FindGameObjectWithTag("Player").transform;
    }


    // Update is called once per frame
    void Update()
    {
        if (nv.destination != targetTr.position)
        {
            nv.SetDestination(targetTr.position);
            anim.SetTrigger("run");

        }

        
        //else
        //{
        //    nv.SetDestination(this.transform.position);
        //    anim.SetBool("isFinish", true);
        //}

    }


}
