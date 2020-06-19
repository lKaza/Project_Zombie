using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomIn = 20f;
    [SerializeField] float zoomOut= 60f;
    [SerializeField] float sensitivityOnZoom=10f;
    private float initialSensitivity;
    RigidbodyFirstPersonController fpsController;

    bool zoomedInToggle = false ;
    // Start is called before the first frame update
    void Start()
    {
        fpsController = GetComponent<RigidbodyFirstPersonController>();
        initialSensitivity = fpsController.mouseLook.XSensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        SetFOV();
        
    }


    public void SetFOV(){
        if(Input.GetMouseButtonDown(1)){
            
            if (zoomedInToggle == false){
                zoomedInToggle = true;
                ChangeSensitivy();
                fpsCamera.fieldOfView = zoomIn;
            }
            else
            {
                zoomedInToggle = false;
                ChangeSensitivy();
                fpsCamera.fieldOfView = zoomOut;
            }
        }
    }
    private void ChangeSensitivy()
    {
        if(zoomedInToggle == true){
            fpsController.mouseLook.XSensitivity = sensitivityOnZoom;
            fpsController.mouseLook.YSensitivity = sensitivityOnZoom;
        }else{
            fpsController.mouseLook.XSensitivity = initialSensitivity;
            fpsController.mouseLook.YSensitivity = initialSensitivity;
        }
       
    }
    
}
