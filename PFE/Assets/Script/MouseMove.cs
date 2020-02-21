using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    public GameObject ps;


    // Update is called once per frame
    void Update()
    {
        Vector3 v3 = Input.mousePosition;
        v3.z = 5.0f;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        ps.transform.position = v3;
    }
}
