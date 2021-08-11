using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OVRPlayerController))]
public class VRController : MonoBehaviour
{
    private OVRPlayerController controller;



    void Start()
    {
        controller = GetComponent<OVRPlayerController>();
     
    }

    void Update()
    {
        //A
        if(OVRInput.GetDown(OVRInput.RawButton.A))
        {
            controller.Jump();

        }

        //B
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        {
            controller.Jump();
        }

        //X
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
           
        }

        //Y
        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            
        }

       
                //if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) && allowDoubleXSpeed)
        {
           // controller.SetMoveScaleMultiplier(moveSpeedMultiplier * 2.0f);
        }
      //  else 
        {
           // controller.SetMoveScaleMultiplier(moveSpeedMultiplier);
        }
    }
}
