using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pointeur : MonoBehaviour
{
    public float m_default_lenght =  0.5f;
    public GameObject m_dot;
    public VRInputModule m_inputModule;
    private LineRenderer m_lineRenderer = null;

    private void Awake(){
        m_lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update(){
        UpdateLine();
    }

    private void UpdateLine()
    {
        //Use default or distance
        //PointerEventData data = m_inputModule.GetData();
        //float targetLength = data.pointerCurrentRaycast.distance == 0 ? m_default_lenght : data.pointerCurrentRaycast.distance;
        float targetLength = m_default_lenght;

        //Raycast
        RaycastHit hit = CreateRaycast(targetLength);

        //Default 
        Vector3 endPosition = transform.position + (transform.forward * targetLength);
       
        //Or based on hit
        if(hit.collider != null){
            endPosition = hit.point;
        }

        //Set position of the dot 
        m_dot.transform.position = endPosition;

        //Set linerenderer
        m_lineRenderer.SetPosition(0, transform.position);
        m_lineRenderer.SetPosition(1, endPosition);
    }

    private RaycastHit CreateRaycast(float lenght){
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, m_default_lenght);
        return hit;
    }
}
