using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanisterGauge : MonoBehaviour
{
    [SerializeField]
    GameObject GaugeMeasure;

    Vector3 startingPosition;
    Vector3 startingScale;
   

    void Start()
    {
        startingPosition = GaugeMeasure.transform.localPosition;
        startingScale = GaugeMeasure.transform.localScale;
        SetGauge(0.8f);
    }

    void Update()
    {

    }

    public void SetGauge(float value)
    {
        float yScale = startingScale.y * value;
        Vector3 setScale = new Vector3(startingScale.x, yScale, startingScale.z);

        float yPosition = startingPosition.y - (1 - yScale);
        Vector3 setPosition = new Vector3(startingPosition.x, yPosition, startingPosition.z);
        
        GaugeMeasure.transform.localScale = setScale;
        GaugeMeasure.transform.localPosition = setPosition;
    }
}
