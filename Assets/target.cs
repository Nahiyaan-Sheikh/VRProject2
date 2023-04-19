using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class target : MonoBehaviour
{
    [SerializeField] GameObject targetCollider;
    [SerializeField] Animator anim;
    [SerializeField] Transform looktarget;
    public SearchObject targets;
    public bool isFound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        
        Rigidbody rb = other.attachedRigidbody;
        
        SearchObject so = rb.GetComponent<SearchObject>();
        
        if (so == targets)
        {
            isFound = true;
            anim.SetTrigger("rotate");
            looktarget.transform.position = targets.transform.position;
        }

    }
}
