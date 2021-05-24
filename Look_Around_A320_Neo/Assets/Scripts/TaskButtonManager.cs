using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskButtonManager : MonoBehaviour
{

    public GameObject TaskManager;
    private TaskManager tm;

    void Start()
    {
        tm = TaskManager.GetComponent<TaskManager>();
    }
    
    public void UseToggle()
    {
        
    }
    
    public void TickTask()
    {
        tm.ActivateNextTask();
    }
}
