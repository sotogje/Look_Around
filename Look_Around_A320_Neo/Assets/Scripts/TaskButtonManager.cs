using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskButtonManager : MonoBehaviour
{
    public GameObject toggle;
    private Toggle tg;

    public GameObject TaskManager;
    private TaskManager tm;

    void Start()
    {
        tg = toggle.GetComponent<Toggle>();
        tm = TaskManager.GetComponent<TaskManager>();
    }
    
    public void UseToggle()
    {
        if (tg.isOn == true)
        {
            tg.isOn = false;
            tm.ActivateNextTask();
        } else if (tg.isOn == false)
        {
            tg.isOn = true;
            tm.ActivateNextTask();
        }
    }
    
    public void TickTask()
    {
        tm.ActivateNextTask();
    }
}
