using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private int taskPosition = 0;
    public GameObject[] task;
    public GameObject[] teleporter;
    public GameObject[] taskText;

    private GameObject currentTask;

    public void ActivateNextTask()
    {
        task[taskPosition].SetActive(false);
        task[taskPosition + 1].SetActive(true);

        teleporter[taskPosition].SetActive(false);
        teleporter[taskPosition + 1].SetActive(true);

        taskText[taskPosition].SetActive(false);
        taskText[taskPosition + 1].SetActive(true);

        taskPosition += 1;


        Debug.Log("next task: " + (taskPosition + 1));


    }

    public int ReturnTaskPosition()
    {
        return taskPosition;
    }
    
}
