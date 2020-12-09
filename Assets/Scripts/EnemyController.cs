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
    private string tagName;
    


    RaycastHit hit;
    public float hitMaxDistance = 10f;
    public float attackRange = 2.0f;       //   몬스터 공격범위.


    // Animation
    private int hashRun = Animator.StringToHash("run");
    private int hashFinish = Animator.StringToHash("isFinish");



    void Start()
    {
        nv = this.GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        targetTr = GameObject.FindGameObjectWithTag("Player").transform;
        monsterTr = this.transform;
    }


    // Update is called once per frame
    void Update()
    {
        var direction = (targetTr.position - monsterTr.transform.position);          // 목표위치와 몬스터의 방향.
        var distance = direction.magnitude;
        if (distance > attackRange)
        {
            nv.SetDestination(targetTr.position);
            nv.isStopped = false;
            anim.SetTrigger(hashRun);
        }
        else if( distance <= attackRange)
        {
            nv.isStopped = true;            //   멈춤.
            anim.SetTrigger(hashFinish);
        }



        Debug.DrawRay(transform.position, transform.forward * hitMaxDistance, Color.blue, 0.3f);
        if (Physics.Raycast(transform.position, transform.forward, out hit, hitMaxDistance))
        {
            //hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
            //Debug.Log(hit.collider.gameObject.name);
            tagName = hit.collider.tag;
        }


    }




}
