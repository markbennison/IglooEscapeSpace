using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject viewScreen;
    public GameObject lights;

    public SmartSpeakerController smartSpeaker;
    public CanisterGauge oxygenCanister;

    bool lightsOn = false;
    bool muteSpeaker = false;
	bool powerOn = false;

	[SerializeField]
	float activityMinutes = 15f;
	float activitySeconds;
	float timeCounter = 0f;
	float timeNormalised;


	// Start is called before the first frame update
	void Start()
    {
		activitySeconds = activityMinutes * 60f;
        timeCounter = activitySeconds;
    }

    // Update is called once per frame
    void Update()
    {
		timeCounter -= Time.deltaTime;
		timeNormalised = timeCounter / activitySeconds;

        oxygenCanister.SetGauge(timeNormalised);

        if (timeCounter <= 0)
        {
			timeCounter = 0f;
			SceneManager.LoadScene("Dead");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            Debug.Log("1");
            viewScreen.GetComponent<ViewerControl>().Open();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            Debug.Log("2");
            viewScreen.GetComponent<ViewerControl>().Close();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
			if (lightsOn)
            {
                lightsOn = false;
				lights.SetActive(false);
				smartSpeaker.VoiceLights(false);

			}
            else
            {
				lightsOn = true;
				lights.SetActive(true);
				smartSpeaker.VoiceLights(true);
			}

			Debug.Log("L: Lights " + lightsOn);
		}

		if (Input.GetKeyDown(KeyCode.M))
		{
			if (muteSpeaker)
			{
				muteSpeaker = false;
				smartSpeaker.SpeakerSwitch(true);
			}
			else
			{
				muteSpeaker = true;
				smartSpeaker.SpeakerSwitch(false);
			}

			Debug.Log("M: Mute Speaker " + muteSpeaker);
		}

		if (Input.GetKeyDown(KeyCode.P))
		{
			if (powerOn)
			{
				powerOn = false;
				lights.SetActive(false);
				smartSpeaker.VoicePower(false);
				viewScreen.GetComponent<ViewerControl>().Close();
			}
			else
			{
				powerOn = true;
				lights.SetActive(true);
				viewScreen.GetComponent<ViewerControl>().Open();
				smartSpeaker.VoicePower(true);
			}

			Debug.Log("L: Lights " + lightsOn);
		}

		if (Input.GetKeyDown(KeyCode.Slash) || Input.GetKeyDown(KeyCode.Question))
		{
			//smartSpeaker.VoiceDifficultyUnderstanding();
			smartSpeaker.VoiceDontKnow();
		}
	}
}