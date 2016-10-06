using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Music : MonoBehaviour {

	public AudioSource musicClip;
	public AudioClip soundBite;
	public List<GameObject> cubes;
	public List<GameObject> speakers;
	public List<float> times;
	public List<GameObject> buttons;
	public float[] drops;
	private int cubeCounter;
	public int switchController;
	public float speakerLength;

	void Start()
	{
		foreach(GameObject item in speakers)
		{
			MeshRenderer meshIsActive = item.GetComponent<MeshRenderer>();
			meshIsActive.enabled = false;
		}
	}

	void OnMouseDown()
	{
		if(int.TryParse (gameObject.name, out switchController))
		{
			Debug.Log ("success");
			Debug.Log (soundBite.name);
		}
		else
			Debug.Log ("fail");
		switch (switchController) 
		{
			case 1:
				Badgers();
				break;
			case 2:
				Babes();
				break;
			case 3:
				Chaumers();
				break;
			case 4:
				Converters();
				break;
		}


	}

	public void Badgers()
	{
		musicClip.clip = soundBite;
		drops = new float[]{1.043f, 3.128f, 4.979f};
		times.Add (2.235f);
		times.Add (2.476f);
		times.Add (4.093f);
		times.Add (4.314f);
		times.Add (6.12f);
		times.Add (6.263f);
		times.Add (6.465f);
		times.Add (6.843f);
		times.Add (7.201f);
		times.Add (7.579f);
		times.Add (7.847f);
		times.Add (8.114f);
		speakerLength = 1.199f;
		musicClip.Play();
		StartCoroutine ("SyncToAudio");
		StartCoroutine ("SyncBassToAudio");
	}

	void Babes()
	{
		musicClip.clip = soundBite;

	}

	void Chaumers()
	{
		musicClip.clip = soundBite;

	}

	void Converters()
	{
		musicClip.clip = soundBite;
	}

	public void Thunderstruck()
	{
		speakerLength = .1f;
		drops = new float[]{29.856f, 30.314f, 31.253f, 32.145f, 33.037f, 33.470f, 33.928f, 34.844f, 35.735f, 36.651f, 
			37.109f, 37.519f, 38.410f, 39.326f, 40.217f, 40.699f, 41.133f, 42.049f, 42.940f, 43.832f, 44.314f, 44.748f, 
			45.639f, 46.531f, 47.47f};
		for( int i = 0; i < 200; i++)
		{
			times.Add (1 + (i * .227f));
		}
		musicClip.Play();
		StartCoroutine ("SyncToAudio");
		StartCoroutine ("SyncBassToAudio");
	}

	IEnumerator SyncBassToAudio(){
		for (int k = 0; k < drops.Length; k++){
			float sampleCalc = drops[k] * musicClip.clip.frequency;
			while (musicClip.timeSamples < sampleCalc) yield return 0; // wait till the desired sample
			foreach(GameObject item in speakers)
			{
				MeshRenderer meshIsActive = item.GetComponent<MeshRenderer>();
				meshIsActive.enabled = !meshIsActive.enabled;
			}
			yield return new WaitForSeconds (speakerLength);
			foreach(GameObject item in speakers)
			{
				MeshRenderer meshIsActive = item.GetComponent<MeshRenderer>();
				meshIsActive.enabled = !meshIsActive.enabled;
			}
		}
	}
	IEnumerator SyncToAudio(){
		for (int k = 0; k < times.Count; k++){
			float sampleCalc = times[k] * musicClip.clip.frequency;
			while (musicClip.timeSamples < sampleCalc) yield return 0; // wait till the desired sample
			if (cubeCounter >= cubes.Count)
				cubeCounter = 0;
			MeshRenderer meshIsActive = cubes[cubeCounter].GetComponent<MeshRenderer>();
			meshIsActive.enabled = !meshIsActive.enabled;
			cubeCounter++;
		}
	}
}