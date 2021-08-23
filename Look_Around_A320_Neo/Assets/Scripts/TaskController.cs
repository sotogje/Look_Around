using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class TaskController : MonoBehaviour
{
    private bool isCorrect = true;
    public GameObject correctObject, incorrectObject;

    public void Start()
    {
        var time = DateTime.Now.Ticks;
        //Debug.Log("time " + time);
        UnityEngine.Random.InitState((int)time);
    }

    public void OnEnable()
    {
        

        int randomCorrect = UnityEngine.Random.Range(0, 2);

        switch (randomCorrect)
        {
            case 0:
                isCorrect = true;
                break;
            case 1:
                isCorrect = false;
                break;
        }


        if (isCorrect)
        {
            correctObject.SetActive(true);
            incorrectObject.SetActive(false);
        }
        else if (!isCorrect)
        {
            correctObject.SetActive(false);
            incorrectObject.SetActive(true);
        }

    }
        
    public void Interact()
    {
        if (isCorrect)
        {
            correctObject.SetActive(false);
            incorrectObject.SetActive(true);
            isCorrect = false;
        } else if (!isCorrect)
        {
            correctObject.SetActive(true);
            incorrectObject.SetActive(false);
            isCorrect = true;
        }
    }

    public bool GetCorrectState()
    {
        return isCorrect;
    }
    
    
}
