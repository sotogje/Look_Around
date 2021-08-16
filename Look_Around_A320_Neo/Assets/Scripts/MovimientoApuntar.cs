using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(OVRPlayerController))]
public class MovimientoApuntar : MonoBehaviour
{
    private OVRPlayerController controller;
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
    public GameObject black_screen;

    public GameObject TaskManager;

    public Camera cam;

    private Animator anim_black;
    private Vector3 teleportPosition;

    private void Start()
    {
        tm = TaskManager.GetComponent<TaskManager>();
        controller=GetComponent<OVRPlayerController>();
        anim_black = black_screen.GetComponent<Animator>();
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        var ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, (Screen.height / 2), 0));

        Debug.DrawRay(ray.origin, ray.direction * 12, Color.yellow);
        
        dot_green.SetActive(false);
        dot_white.SetActive(true);

        if (Physics.Raycast(ray, out hit, 30))
        {
            var selection = hit.transform;
            //Debug.Log(hit.transform.name);
            
            if (selection.tag == "teleport")
            {
                dot_green.SetActive(true);
                dot_white.SetActive(false);

                if (Input.GetMouseButton(1))
                {
                    teleportPosition = selection.transform.position;
                    StartCoroutine("Teleport");
                }

                if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    teleportPosition = selection.transform.position;
                    StartCoroutine("Teleport");

                }

            }

        

        }
    }

    private IEnumerator Teleport()
    {
        anim_black.SetBool("Fade", true);
        yield return new WaitForSeconds(1.0f);

        anim_black.SetBool("Fade", false);
        player.transform.position = teleportPosition;
    }
}
