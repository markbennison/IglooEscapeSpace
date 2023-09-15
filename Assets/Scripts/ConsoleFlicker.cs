using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConsoleFlicker : MonoBehaviour
{
    TextMeshPro textMeshPro;

    string text = "Door access ...<br>DENIED<br><br>Boot disk missing!<br>";
    string textWithUnderscore = "Door access ...<br>DENIED<br><br>Boot disk missing!<br>_";

    bool withUnderscore = false;

    float counter;
    float secondsToChange = 0.7f;

    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
        counter = secondsToChange;
        
    }


    void Update()
    {
        counter -= Time.deltaTime;
        Debug.Log(counter);
        if (counter <= 0 )
        {
            counter = secondsToChange;
            if(withUnderscore)
            {
                withUnderscore = false;
                textMeshPro.text = textWithUnderscore;
            }
            else
            {
                withUnderscore = true;
                textMeshPro.text = text;
            }
        }
    }
}
