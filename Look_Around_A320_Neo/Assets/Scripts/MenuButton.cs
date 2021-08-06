using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public int type;        //0. change scene
    public string scene;
    
    public void UseButton()
    {
        if (type == 0)
        {
            StartCoroutine("ChangeScene");
        }
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene(scene);
    }
}
