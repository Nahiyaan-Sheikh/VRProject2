using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class testScript : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform target;
    [SerializeField] Rigidbody physics;
    [SerializeField] Animator body;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float speed = 2;
    // Update is called once per frame
    void Update()
    {
        var step = 0.5f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);    
        }
}
