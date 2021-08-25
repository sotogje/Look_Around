using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    float defaultFov;
    float zoomFov;
    float currentFov;
    public float zoomSpeed;
    float targetFov;
    
    void Start()
    {
        defaultFov = 60f;
        zoomFov = 30f;
        targetFov = defaultFov;
    }
    
    void Update()
    {
        var cameraFov = Camera.main.fieldOfView;
        
        if (Input.GetMouseButtonDown(1))
        {
            targetFov = zoomFov;
            Debug.Log("Zoom");
        }

        if (Input.GetMouseButtonUp(1))
        {
            targetFov = defaultFov;
            Debug.Log("Normal");
        }

        currentFov = Mathf.Lerp(cameraFov, targetFov, zoomSpeed);

        Camera.main.fieldOfView = currentFov;
    }
    
}
