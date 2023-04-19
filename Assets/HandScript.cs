using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject targetcollider;
    [SerializeField] Transform place;
    public SearchObject targets;
    public bool isFound;
    public float seconds = 1;
    public float timer;
    public float percent;
    public Vector3 start;
    public Vector3 diff;

    // Start is called before the first frame update
    void Start()
    {
        
        start = place.transform.position;
        diff = target.transform.position - start;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFound)
        {
            if (timer <= seconds)
            {
                // basic timer
                timer += Time.deltaTime/.4f;
                // percent is a 0-1 float showing the percentage of time that has passed on our timer!
                percent = timer / seconds;
                // multiply the percentage to the difference of our two positions
                // and add to the start
                transform.position = start + diff * percent;
            }
            this.transform.rotation = target.transform.rotation;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
            Rigidbody rb = other.attachedRigidbody;

            SearchObject so = rb.GetComponent<SearchObject>();

            if (so == targets)
            {
                isFound = true;
                this.transform.position = place.transform.position;
            }

    }
}
