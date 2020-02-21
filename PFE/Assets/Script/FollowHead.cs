using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHead : MonoBehaviour
{
    public Transform head;
    public Transform body;

    // Update is called once per frame
    void LateUpdate()
    {
        body.position = head.position + (new Vector3(0,0.5f,0));
    }
}
