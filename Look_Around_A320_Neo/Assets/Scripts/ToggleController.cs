using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    public GameObject toggle;
    private Toggle tg; 

    void Start()
    {
        tg = toggle.GetComponent<Toggle>();

    }
    
    public void UseToggle()
    {
        if (tg.isOn == true)
        {
            tg.isOn = false;
        }
        else if (tg.isOn == false)
        {
            tg.isOn = true;
        }
    }
}
