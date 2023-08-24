using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ViewerControl : MonoBehaviour
{
    [Range(0.0f, 1.0f)]
    public float opening;

    //public float openCloseTime = 2f;

    private float tempOpening;
    private float closeYPosition = 0.4f;
    private float openYPosition = 3.4f;

    private float openCloseSpeed = 0f;
    private float openCloseTimeLeft;

    void Start()
    {
        tempOpening = 0;
        ViewerChange();
    }

    // Update is called once per frame
    void Update()
    {
        OpenClose();
    }

    void ViewerChange()
	{
        tempOpening = opening;
        transform.position = new Vector3(0f, Mathf.Lerp(closeYPosition, openYPosition, opening), 0f);
        RenderSettings.ambientIntensity = opening;
    }

    public void Open()
	{
        openCloseSpeed = 1f;
    }

    public void Close()
    {
        openCloseSpeed = -1f;
    }

    void OpenClose()
	{
        opening += openCloseSpeed * Time.deltaTime;

        if (opening > 1f)
		{
            opening = 1f;
            openCloseSpeed = 0f;
        }
        else if (opening < 0f)
        {
            opening = 0f;
            openCloseSpeed = 0f;
        }

        Debug.Log(opening);

        if (opening != tempOpening)
        {
            ViewerChange();
        }
    }
}
