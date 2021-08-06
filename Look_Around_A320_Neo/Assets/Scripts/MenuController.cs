using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuController : MonoBehaviour
{
    public GameObject textObject;
    private TextMeshProUGUI text;

    void Awake()
    {
        Debug.Log(ScoreManager.GetScore());
        if (ScoreManager.GetScore() != 0)
        {

            Debug.Log(ScoreManager.GetScore());
            text = textObject.GetComponent<TextMeshProUGUI>();
            text.SetText("Score: " + ScoreManager.GetScore().ToString());

        }
    }
    
    void Update()
    {
        
    }
}
