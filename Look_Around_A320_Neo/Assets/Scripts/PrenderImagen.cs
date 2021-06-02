using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrenderImagen : MonoBehaviour
{
    public GameObject audifonosImagen;
    public bool tieneAudifonos = false;
    
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            tieneAudifonos = true;
        }

        if (tieneAudifonos == true)
        {
            audifonosImagen.SetActive(true);
        }
    }
}
