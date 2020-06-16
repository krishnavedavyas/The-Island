using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] Transform targetA;
    [SerializeField] Transform targetB;
    [SerializeField] Transform targetC;
    [SerializeField] Transform targetD;
    [SerializeField] Transform targetE;
    [SerializeField] Transform targetF;
    [SerializeField] Transform targetG;
    [SerializeField] Transform targetH;
    [SerializeField] Transform targetI;
    [SerializeField] Transform targetJ;
    [SerializeField] int waitTime;
    [SerializeField] int enemyNumber;
    [SerializeField] string targetName;
    [SerializeField] string targetDescriptor;
    int currentTarget = 1;
    Animator anim;
    int lastTarget=1;
    Transform Destination;
    bool contact = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        Destination = targetA;
        lastTarget = currentTarget;
        targetDescriptor = enemyNumber + "target1";
        moveTowardsTarget();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyTarget")
        {
            targetName = other.GetComponent<Collider>().name;
            if (targetName == targetDescriptor)
            { 
                if (contact == false)
                {
                    contact = true;
                    currentTarget = Random.Range(1, 11);
                    if (currentTarget == lastTarget)
                    {
                        tryAgain();
                    }
                    else
                    {
                        StartCoroutine(waiting());
                    }

                }
        }
        }
    }
    void tryAgain()
    {
        if(lastTarget==1)
        {
            currentTarget = lastTarget + 1;
        }
        else if(lastTarget>1)
        {
            currentTarget = lastTarget - 1;
        }
        StartCoroutine(waiting());
    }
    IEnumerator waiting()
    {
        anim.SetBool("lookaround", true);
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("lookaround", false);
        contact = false;
        moveTowardsTarget();
    }
    void moveTowardsTarget()
    {
        if(currentTarget==1)
        {
            Destination = targetA;
            targetDescriptor = enemyNumber + "target1";
        }
       else if (currentTarget == 2)
        {
            Destination = targetB;
            targetDescriptor = enemyNumber + "target2";
        }
       else if (currentTarget == 3)
        {
            Destination = targetC;
            targetDescriptor = enemyNumber + "target3";
        }
        else if (currentTarget == 4)
        {
            Destination = targetD;
            targetDescriptor = enemyNumber + "target4";
        }
        else if (currentTarget == 5)
        {
            Destination = targetE;
            targetDescriptor = enemyNumber + "target5";
        }
        else if (currentTarget == 6)
        {
            Destination = targetF;
            targetDescriptor = enemyNumber + "target6";
        }
        else if (currentTarget == 7)
        {
            Destination = targetG;
            targetDescriptor = enemyNumber + "target7";
        }
        else if (currentTarget == 8)
        {
            Destination = targetH;
            targetDescriptor = enemyNumber + "target8";
        }
        else if (currentTarget == 9)
        {
            Destination = targetI;
            targetDescriptor = enemyNumber + "target9";
        }
        else if (currentTarget == 10)
        {
            Destination = targetJ;
            targetDescriptor = enemyNumber + "target10";
        }
        GetComponent<NavMeshAgent>().destination = Destination.position;
        lastTarget = currentTarget;
    }
   
}
