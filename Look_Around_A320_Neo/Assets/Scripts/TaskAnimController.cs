using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskAnimController : MonoBehaviour
{
    public bool isCorrect = true;
    public Animator anim;

    public void OnEnable()
    {
        int randomCorrect = Random.Range(0, 2);

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
            anim.SetBool("isCorrect", false);
        }
        else if (!isCorrect)
        {
            anim.SetBool("isCorrect", true);
        }

    }

    public void Interact()
    {
        if (isCorrect)           //door state is correct, door is closed and will be opened
        {
            anim.SetBool("isCorrect", true);
            isCorrect = false;
        }
        else if (!isCorrect)     //door state is incorrect, door is open and will be closed
        {
            anim.SetBool("isCorrect", false);
            isCorrect = true;
        }
    }

    public bool GetCorrectState()
    {
        return isCorrect;
    }


}
