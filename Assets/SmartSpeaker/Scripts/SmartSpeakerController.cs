using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmartSpeakerController : MonoBehaviour
{
    public GameObject speakerLight;
    Material lightMaterial;

    float upDownTimer = 0;
    float upDownTimerNormalised;
	float timerLimit = 2f;
    float timerLimitNormaliser;
    bool timerGoingUp = true;

    float intensityValue;
    Color defaultColor = new Color(0f, 255f, 255f);
    Color colorChange;

    float maxIntensity = 0.004f;


	void Start()
    {
		lightMaterial = speakerLight.GetComponent<Renderer>().material;
        //intensityMultiplier = 1 / maxIntensity;
        timerLimitNormaliser = 1 / timerLimit;
	}


    void Update()
    {
		LightPulse(true);

	}

    void LightPulse(bool on)
    {
		if (on)
		{
			if (timerGoingUp)
			{
				upDownTimer += Time.deltaTime;
				if (upDownTimer > timerLimit)
				{
					upDownTimer = timerLimit;
					timerGoingUp = false;
				}
			}
			else
			{
				upDownTimer -= Time.deltaTime;
				if (upDownTimer < 0)
				{
					upDownTimer = 0;
					timerGoingUp = true;
				}
			}

			upDownTimerNormalised = upDownTimer * timerLimitNormaliser;
			intensityValue = upDownTimerNormalised * maxIntensity;

			colorChange = defaultColor * intensityValue;

			lightMaterial.SetColor("_EmissionColor", colorChange);
		}
	}
}
