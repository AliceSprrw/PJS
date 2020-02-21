using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;
public class VRInputModule : BaseInputModule
{

    public Camera m_Camera;
    public SteamVR_Input_Sources m_TargetSource;
    public SteamVR_Action_Boolean m_ClickAction;


    private GameObject m_current_object = null;
    private PointerEventData m_Data = null;

    protected override void Awake(){
        base.Awake();

        m_Data = new PointerEventData(eventSystem);
    }


    public override void Process(){
        //Reset data, set camera
        m_Data.Reset();
        m_Data.position = new Vector2(m_Camera.pixelWidth / 2, m_Camera.pixelHeight / 2);
       
        //Raycast
        eventSystem.RaycastAll(m_Data, m_RaycastResultCache);
        m_Data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        m_current_object = m_Data.pointerCurrentRaycast.gameObject;

        //Clear raycast
        m_RaycastResultCache.Clear();

        //Hover
        HandlePointerExitAndEnter(m_Data, m_current_object);

        //Press
        if(m_ClickAction.GetStateDown(m_TargetSource)){
            ProcessPress(m_Data);
        }

        //Release
        if(m_ClickAction.GetStateUp(m_TargetSource)){
            ProcessRelease(m_Data);
        }
    }

    public PointerEventData GetData(){
        return m_Data;
    }


    private void ProcessPress(PointerEventData data){
        //set raycast 
        data.pointerPressRaycast = data.pointerCurrentRaycast;

        // Check for the object hit, get the down handler, call
        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(m_current_object, data, ExecuteEvents.pointerDownHandler);

        // if no handler, try and get click handler
        if(newPointerPress == null){
            newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_current_object);
        }

        // Set data
        data.pressPosition = data.position;
        data.pointerPress = newPointerPress;
        data.rawPointerPress = m_current_object;
    }

    private void ProcessRelease(PointerEventData data){

        // Execute pointer up
        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);
        
        //check click handler
        GameObject pointerupHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(m_current_object);

        // check if actual
        if(data.pointerPress == pointerupHandler){
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }

        // clear selected gameobject
        eventSystem.SetSelectedGameObject(null);

        //reset data
        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;
    }
}
