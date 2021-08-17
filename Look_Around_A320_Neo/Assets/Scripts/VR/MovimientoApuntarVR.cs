using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MovimientoApuntarVR : MonoBehaviour
{
    public bool rightHand;
    private float rayDir;


    public GameObject menu;


    private OVRPlayerController controller;
    public LayerMask layerMask = 2;
    private TaskController tc;
    private TaskButtonManager tbm;
    private TaskManager tm;
    private ToggleController tg;
    private TaskAnimController tac;

    RaycastHit hit;

    public GameObject player;


    public GameObject TaskManager;

    private Animator anim_black;
    private Vector3 teleportPosition;

    private void Start()
    {
        rayDir = rightHand == true ? 1 : -1;


        tm = TaskManager.GetComponent<TaskManager>();
        controller = GetComponentInParent<OVRPlayerController>();
       
    }

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {

            bool isActive = menu.activeSelf;

            menu.SetActive(!isActive);

        }

       


        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back) * rayDir, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * rayDir * hit.distance, Color.green);

            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                Debug.Log("Trigger Izquierdo Presionado");
            }

            if (hit.transform.tag == "teleport")
 
                {

                if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    
                    Vector3 newPosition = new Vector3(hit.transform.position.x, player.transform.position.y, hit.transform.position.z);

                    teleportPosition = newPosition;

                        StartCoroutine("Teleport");

                    }
                }
        }

        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.back) * rayDir * 1000, Color.red);

        }

    }

    private IEnumerator Teleport()
    {
       // anim_black.SetBool("Fade", true);
        yield return new WaitForSeconds(1.0f);

       // anim_black.SetBool("Fade", false);
        player.transform.position = teleportPosition;
    }
}
