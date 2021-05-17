using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public bool isCorrect = true;
    public GameObject correctObject, incorrectObject;

    public int position;

    void Start()
    {
        if (isCorrect)
        {
            correctObject.SetActive(true);
            incorrectObject.SetActive(false);
        } else if (!isCorrect)
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
    
    
}
