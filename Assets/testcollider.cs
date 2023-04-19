using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testcollider : MonoBehaviour
{
    [SerializeField] GameObject targetcollider;
    public bool isFound;
    public SearchObject targets;
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
        }

    }
}
