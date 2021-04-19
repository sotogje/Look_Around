using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoApuntar : MonoBehaviour
{
    private LayerMask layerMask = 2;

    RaycastHit hit;

    public GameObject player;
    public GameObject dot_white;
    public GameObject dot_green;

    private void FixedUpdate()
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
            
            Debug.Log(selection.name);
            
            if (selection.tag == "teleport")
            {
                dot_green.SetActive(true);
                dot_white.SetActive(false);

                if (Input.GetMouseButton(0))
                {

                    player.transform.position = selection.transform.position;
                }
            }

        }
    }
}
