using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Person : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;
    [SerializeField] Rigidbody physics;
    [SerializeField] Animator body;
    [SerializeField] Transform rightHandTarget;
    [SerializeField] Transform headTarget;
    public float offsetx;
    public float offsety;
    private Transform headtemp;
    // Start is called before the first frame update
    void Start()
    {
        agent.updatePosition = false;
        headtemp = headTarget;
    }

    private void OnAnimatorIK(int layerIndex)
    {
        body.SetLookAtPosition(headTarget.position);
        body.SetLookAtWeight(1.0f);
        body.SetIKPosition(AvatarIKGoal.RightHand, rightHandTarget.position);
        body.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);

        body.SetIKRotation(AvatarIKGoal.RightHand, rightHandTarget.rotation);
        body.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);

    }
    private void OnAnimatorMove()
    {
        transform.position = body.rootPosition;
        //agent.nextPosition = body.rootPosition;
    }
    // LateUpdate after animation completes
    void LateUpdate()
    {
        Vector3 targetDirection = target.position - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, .05f, .05f);
        transform.rotation = Quaternion.LookRotation(newDirection);
        Vector3 offset = target.position - transform.position;
        offsetx = offset.x;
        offsety = offset.y;
        if (Mathf.Abs(offset.x) < 0.09 && Mathf.Abs(offset.z) < 0.09)
        {
            body.SetBool("walking", false);
            headTarget = headtemp;
            targetDirection = target.position - transform.position;
            newDirection = Vector3.RotateTowards(transform.forward, targetDirection, .05f, .05f);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
        else
        {
            body.SetBool("walking", true);
            headTarget = null;
        }

        agent.SetDestination(target.position);
        
        
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        //body.SetFloat("walkspeed", agent.desiredVelocity.magnitude);


        body.SetFloat("walkspeed", 1);
       
    }
}
