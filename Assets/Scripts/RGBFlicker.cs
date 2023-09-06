using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RGBFlicker : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Lights = new List<GameObject>();

    [SerializeField]
    float lightOnTime = 3f;

    float timer;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        timer = lightOnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            timer = lightOnTime;
            index++;
            if (index >= Lights.Count)
            {
                index = -1;
            }

            SwitchOffAllLights();

            if (index >= 0)
            {
                Lights[index].SetActive(true);
            }

                
        }


    }

    void SwitchOffAllLights()
    {
        foreach (GameObject light in Lights)
        {
            light.SetActive(false);
        }
    }
}
