using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessMale1 : MonoBehaviour
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
            anim.SetBool("checkshoes", true);
        }
        else
            anim.SetBool("checkshoes", false);
        if (idFound)
        {
            anim.SetBool("talkphone", true);
        }
        else
            anim.SetBool("talkphone", false);
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
