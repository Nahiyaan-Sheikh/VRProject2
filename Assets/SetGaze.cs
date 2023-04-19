using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGaze : MonoBehaviour
{

    [SerializeField] Transform eyeCenter;
    [SerializeField] Transform eyeDirection;
    public Transform lookAtTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion prevRotation = eyeDirection.localRotation;
        eyeDirection.LookAt(lookAtTarget);
        Quaternion targetRotation = eyeDirection.rotation;

        eyeDirection.localRotation = prevRotation;

        eyeCenter.rotation = targetRotation * Quaternion.Inverse(eyeDirection.localRotation);
    }
}
