using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeHand : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject targetcollider;
    [SerializeField] Transform restPosition;
    public SearchObject targets;
    public bool isFound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFound)
        {
            this.transform.position = target.transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
    
        Rigidbody rb = other.attachedRigidbody;
      
        SearchObject so = rb.GetComponent<SearchObject>();

        if (so == targets)
        {
            isFound = true;
            this.transform.position = target.transform.position;
        }

    }
    private void OnTriggerExit(Collider other)
    {

        Rigidbody rb = other.attachedRigidbody;

        SearchObject so = rb.GetComponent<SearchObject>();

        if (so == targets)
        {
            isFound = false;
            this.transform.position = restPosition.transform.position;
        }

    }
}
