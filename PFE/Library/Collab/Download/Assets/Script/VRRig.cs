using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackinPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map(float ofset)
    {
        rigTarget.position = vrTarget.TransformPoint(trackinPositionOffset) ;
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);

    }
}

public class VRRig : MonoBehaviour
{

    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    public Transform headConstraint;
    public Vector3 headBodyOffset;
    public float turnSmoothness;

    // Start is called before the first frame update
    void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = headConstraint.position + headBodyOffset;
        //transform.forward = Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized;
        transform.forward = Vector3.Lerp(transform.forward,Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized,Time.deltaTime * turnSmoothness);


        head.Map(1.2f);
        leftHand.Map(0);
        rightHand.Map(0);
    }
}
