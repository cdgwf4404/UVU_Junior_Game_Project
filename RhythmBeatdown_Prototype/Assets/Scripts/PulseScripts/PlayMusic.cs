using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayMusic : MonoBehaviour {
	private int counter;
	public AudioSource musicClip;
	public AudioClip soundBite;
	private float beat;
	private float displayLength = 0.25f;//0.1
	private Vector3 initialDisplay;
	private Vector3 fullDisplay;
	public GameObject displayCube;
	public float expandLerpTimeScale = 2;//2
	public float returnLerpTimeScale = 1;//1
	public static bool onBeat= false;
	private Color green = Color.green;
	private Color red = Color.red;

	private GameObject coyoteIcon;
	private Vector3 coyNrmScl;
	private Vector3 coyBeatScl;
	private bool setupDelay = false;
	public float waitTime = 0.02f;
	public static float soloTimer = 0;
	private float timeSinceStart = 0;
	private bool soloModeOneStart = false;

	public delegate void soloModeStart();
	public static event soloModeStart OnStart;
	public int quarterBeatsnum;
	public static bool turnOff= false;




	public AudioSource newSong;

	// Use this for initialization
	void Start () {
		counter = 1;
		//beat = 0.6784736842f;
		//beat = 0.760666f;
		beat = 0.645767f;
		initialDisplay = displayCube.transform.localScale;
		fullDisplay = new Vector3(2.5f, 2.5f, 2.5f);

		coyoteIcon = GameObject.Find ("Coyote_Icon");
		coyNrmScl = coyoteIcon.transform.localScale;
		coyBeatScl = new Vector3 (1.2f, 1.2f, 1.2f);
		StartActivateDisplay ();
		StartCoroutine(checkQuarterBeats ());
	}

	void StartActivateDisplay()
	{
		StartCoroutine ("ActivateDisplay");
	}



	IEnumerator beatsSpeed()
	{
		if(Time.time >= 69f+timeSinceStart && turnOff ==false)//69seconds into the song for the first solomode
		{
			soloModeOneStart = true;
			SoloModeButtons.SoloMode = true;
			print ("69seconds plus" + timeSinceStart);
			if (OnStart != null) {
				print ("quarter");
				OnStart ();
			}
		}

		if(Time.time >=90 + timeSinceStart)
		{
			//turnOff = true;
			yield return new WaitForSeconds (0);
		}
		if (Time.time >= 79f + timeSinceStart)
		{
			yield return new WaitForSeconds (beat/4f);
			StartCoroutine (checkQuarterBeats ());
		}else
		{
			yield return new WaitForSeconds (beat/2f);
			StartCoroutine(halfSpeed ());
		}




	}

	IEnumerator checkQuarterBeats()
	{
		yield return new WaitForSeconds (beat / 4f);
		StartCoroutine (beatsSpeed ());
	}
	IEnumerator halfSpeed()
	{
		yield return new WaitForSeconds (beat / 2f);
		StartCoroutine (beatsSpeed ());
	}


	IEnumerator ActivateDisplay(){
		print ("Coroutine Started");
		print ("onbeat");
		if (setupDelay == false)
		{
			StartCoroutine (delay ());
			setupDelay = true;
		}

		if (newSong.isPlaying == false) {
			newSong.Play ();
			timeSinceStart = Time.time;
		}


		//print (timeSinceStart);
		//print (SoloModeButtons.SoloMode);
		//if(Time.time >= 5f+timeSinceStart)
		//{
			//soloModeOneStart = true;
			//SoloModeButtons.SoloMode = true;
			//print ("110seconds plus" + timeSinceStart);
			//if (OnStart != null) {
			//	print ("subscribed");
			//	OnStart ();
			//}
		//}
	
		coyoteIcon.transform.localScale = Vector3.Lerp (coyNrmScl, coyBeatScl, Time.deltaTime * returnLerpTimeScale);
		displayCube.transform.localScale = Vector3.Lerp (fullDisplay, initialDisplay, Time.deltaTime * returnLerpTimeScale);
		displayCube.GetComponent<MeshRenderer> ().material.color = Color.green;
		displayCube.transform.localScale = Vector3.one;
		coyoteIcon.transform.localScale = coyNrmScl;
		onBeat = true;
		yield return new WaitForSeconds (beat);
		displayCube.GetComponent<MeshRenderer> ().material.color = Color.red;
		displayCube.transform.localScale = Vector3.one*2f;
		print ("offbeat");
		onBeat = false;
		StartCoroutine (OffBeat ());

	}

	IEnumerator OffBeat()
	{
		
	yield return new WaitForSeconds (beat);
		//print (Time.time);
		StartCoroutine (ActivateDisplay ());
	}



	IEnumerator delay()
	{
		
		yield return new WaitForSeconds (waitTime);
		
	

	}
		/*for (counter = 1; counter < 500; counter++){
			double sampleCalc = counter * beat * soundBite.frequency;
			while (musicClip.timeSamples < sampleCalc) yield return 0; // wait till the desired sample
			onBeat = true;
			print("on beat");
			displayCube.transform.localScale = Vector3.Lerp(fullDisplay, initialDisplay, Time.deltaTime * returnLerpTimeScale);
			displayCube.GetComponent<MeshRenderer> ().material.color = Color.green;
			yield return new WaitForSeconds (displayLength);
			onBeat = false;
			displayCube.GetComponent<MeshRenderer> ().material.color = Color.red;
			displayCube.transform.localScale = Vector3.Lerp(initialDisplay, fullDisplay, Time.deltaTime * expandLerpTimeScale);

		}*/
	
	
	// Update is called once per frame
	void Update () {


	}
}
