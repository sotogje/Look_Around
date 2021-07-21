using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccionApuntar : MonoBehaviour
{
    private LayerMask layerMask = 2;
    private TaskController tc;
    private TaskButtonManager tbm;
    private TaskManager tm;
    private ToggleController tg;
    private TaskAnimController tac;

    RaycastHit hit;

    public GameObject player;
    public GameObject dot_white;
    public GameObject dot_green;

    public GameObject TaskManager;

    public GameObject audifonos_icono;
    public GameObject chaleco_icono;

    private void Start()
    {
        tm = TaskManager.GetComponent<TaskManager>();
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, (Screen.height / 2), 0));

        Debug.DrawRay(ray.origin, ray.direction * 12, Color.yellow);

        dot_green.SetActive(false);
        dot_white.SetActive(true);

        if (Physics.Raycast(ray, out hit, 30))
        {
            var selection = hit.transform;
            //Debug.Log(hit.transform.name);
            
            if (selection.tag == "audifonos")
            {

                dot_green.SetActive(true);
                dot_white.SetActive(false);

                if (Input.GetMouseButton(0))
                {
                    selection.gameObject.SetActive(false);
                    audifonos_icono.SetActive(true);
                }
            }

            if (selection.tag == "chaleco")
            {
                dot_green.SetActive(true);
                dot_white.SetActive(false);

                if (Input.GetMouseButton(0))
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

                if (Input.GetMouseButtonUp(0))
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


                if (Input.GetMouseButtonUp(0))
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

                if (Input.GetMouseButtonUp(0))
                {
                    tbm.TickTask();
                }
            }

            if (selection.tag == "toggle")
            {
                dot_green.SetActive(true);
                dot_white.SetActive(false);

                tg = selection.gameObject.GetComponent<ToggleController>();

                if (Input.GetMouseButtonUp(0))
                {
                    tg.UseToggle();
                }
            }

        }
    }
}
