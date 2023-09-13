using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SmartSpeakerController : MonoBehaviour
{
	public GameObject speakerLight;
	Material lightMaterial;

	[SerializeField] AudioSource difficultyUnderstanding;
	[SerializeField] AudioSource dontKnow;
	[SerializeField] AudioSource lightsOff;
	[SerializeField] AudioSource lightsOn;
	[SerializeField] AudioSource powerOff;
	[SerializeField] AudioSource powerOn;
	[SerializeField] AudioSource voiceDeactivated;

	float upDownTimer = 0;
	float upDownTimerNormalised;
	float timerLimit = 2f;
	float timerLimitNormaliser;
	bool timerGoingUp = true;

	float intensityValue;
	Color defaultColor = new Color(0f, 255f, 255f);
	Color colorChange;

	float maxIntensity = 0.004f;

	bool pulse = true;

	void Start()
	{
		lightMaterial = speakerLight.GetComponent<Renderer>().material;
		//intensityMultiplier = 1 / maxIntensity;
		timerLimitNormaliser = 1 / timerLimit;

	}


	void Update()
	{
		LightPulse(pulse);
	}

	public void SpeakerSwitch(bool on)
	{
		if (on)
		{
			pulse = true;
			colorChange = defaultColor * intensityValue;
			lightMaterial.SetColor("_EmissionColor", colorChange);
		}
		else
		{
			PlaySound(voiceDeactivated);
			pulse = false;
			colorChange = new Color(255f, 0f, 0f);
			lightMaterial.SetColor("_EmissionColor", colorChange);
		}
	}

	public void VoiceLights(bool on)
	{
		if (on)
		{
			PlaySound(lightsOn);
		}
		else
		{
			PlaySound(lightsOff);
		}
	}

	public void VoicePower(bool on)
	{
		if (on)
		{
			PlaySound(powerOn);
		}
		else
		{
			PlaySound(powerOff);
		}
	}

	public void VoiceDontKnow()
	{
		PlaySound(dontKnow);
	}

	public void VoiceDifficultyUnderstanding()
	{
		PlaySound(difficultyUnderstanding);
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

	void PlaySound(AudioSource audioSource)
	{
		if (audioSource.isPlaying)
		{
			return;
		}

		audioSource.Play();
	}
}