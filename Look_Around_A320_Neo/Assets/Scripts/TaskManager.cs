using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    private int taskPosition = 0;
    public GameObject[] task;
    public GameObject[] teleporter;
    public GameObject[] taskText;

    private GameObject currentTask;

    public GameObject scoreObject;
    private TextMeshProUGUI scoreText;
    private int score;
    private TaskController tc;
    private TaskAnimController tac;

    private BoxCollider bc;

    public void ActivateNextTask()
    {
        if (task.Length - 1 > (taskPosition))
        {
            Debug.Log("Task length: " + task.Length);
            Debug.Log("Task performed " + (taskPosition));

            bc = task[taskPosition].GetComponent<BoxCollider>();
            bc.enabled = false;

            bc = task[taskPosition + 1].GetComponent<BoxCollider>();
            bc.enabled = true;

            //task[taskPosition].SetActive(false);
            //task[taskPosition + 1].SetActive(true);

            teleporter[taskPosition].SetActive(false);
            teleporter[taskPosition + 1].SetActive(true);

            taskText[taskPosition].SetActive(false);
            taskText[taskPosition + 1].SetActive(true);

            taskPosition += 1;

            
        } else
        {
            task[taskPosition].SetActive(false);
            teleporter[taskPosition].SetActive(false);
            taskText[taskPosition].SetActive(false);
            

            for (int i = 0; i < task.Length; i++)
            {
                tc = task[i].GetComponent<TaskController>();
                tac = task[i].GetComponent<TaskAnimController>();


                if (tc != null)
                {
                    if (tc.GetCorrectState())
                    {
                        score += 1;
                    }
                }

                if (tac != null)
                {
                    if (tac.GetCorrectState())
                    {
                        score += 1;
                    }
                }
                
            }

            ScoreManager.SetScore(score);

            Debug.Log("FInal sc: " + ScoreManager.GetScore());
            scoreObject.SetActive(true);
            scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
            scoreText.SetText("Score: " + score.ToString());

        }


    }



    public int ReturnTaskPosition()
    {
        return taskPosition;
    }
    
}
