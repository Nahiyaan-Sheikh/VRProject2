using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingMan : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject targetcollider;
    public bool isFound;
    public bool idFound;
    public SearchObject targets;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isFound)
        {
            anim.SetBool("yawn", true);
        }
        else
            anim.SetBool("yawn", false);
        if (idFound)
        {
            anim.SetBool("idle", true);
        }
        else
            anim.SetBool("idle", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;

        SearchObject so = rb.GetComponent<SearchObject>();

        if (so == targets)
        {
            isFound = true;
            idFound = false;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;

        SearchObject so = rb.GetComponent<SearchObject>();

        if (so == targets)
        {
            isFound = false;
            idFound = true;
        }

    }

}