using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccionApuntarVR : MonoBehaviour
{

    public bool rightHand;
    private float rayDir;


    private OVRPlayerController controller;
    public LayerMask layerMask = 2;
    private TaskController tc;
    private TaskButtonManager tbm;
    private TaskManager tm;
    private ToggleController tg;
    private TaskAnimController tac;
    private MenuButton mb;

    RaycastHit hit;

    public GameObject player;
    public GameObject dot_white;
    public GameObject dot_green;

    public GameObject TaskManager;

    public GameObject audifonos_icono;
    public GameObject chaleco_icono;

    private void Start()
    {

        rayDir = rightHand == true ? 1 : -1;
        controller = GetComponentInParent<OVRPlayerController>();
        tm = TaskManager.GetComponent<TaskManager>();
    }

    private void Update()
    {


        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * rayDir, out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDir * hit.distance, Color.green);

            var selection = hit.transform;


            if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
            {
                Debug.Log("Trigger Derecho Presionado");
            }
            
            if (selection.tag == "audifonos")
            {

                dot_green.SetActive(true);
                dot_white.SetActive(false);

                if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                 
                    selection.gameObject.SetActive(false);
                    audifonos_icono.SetActive(true);
                }
            }

            if (selection.tag == "chaleco")
            {
                dot_green.SetActive(true);
                dot_white.SetActive(false);

                if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                    selection.gameObject.SetActive(false);
                    chaleco_icono.SetActive(true);
                }
            }

            if (selection.tag == "task")
            {

                dot_green.SetActive(true);
                dot_white.SetActive(false);

                int taskPosition = tm.ReturnTaskPosition();

                if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                    tc = selection.GetComponent<TaskController>();
                    tc.Interact();
                    //tm.ActivateNextTask();
                }
            }

            if (selection.tag == "taskAnim")
            {

                dot_green.SetActive(true);
                dot_white.SetActive(false);

                int taskPosition = tm.ReturnTaskPosition();


                if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {

                    tac = selection.GetComponent<TaskAnimController>();
                    tac.Interact();
                    //tm.ActivateNextTask();
                }
            }

            if (selection.tag == "button")
            {
                dot_green.SetActive(true);
                dot_white.SetActive(false);

                tbm = selection.gameObject.GetComponent<TaskButtonManager>();

                if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                    tbm.TickTask();
                }
            }

            if (selection.tag == "toggle")
            {
                dot_green.SetActive(true);
                dot_white.SetActive(false);

                tg = selection.gameObject.GetComponent<ToggleController>();

                if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                    tg.UseToggle();
                }
            }

            if (selection.tag == "menuButton")
            {
                dot_green.SetActive(true);
                dot_white.SetActive(false);

                mb = selection.gameObject.GetComponent<MenuButton>();

                if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                    mb.UseButton();
                }


            }




        }

        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * rayDir * 1000, Color.red);

            dot_green.SetActive(false);
            dot_white.SetActive(true);
        }

    }


}
