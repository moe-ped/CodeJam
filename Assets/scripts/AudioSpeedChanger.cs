using UnityEngine;
using System.Collections;

public class AudioSpeedChanger : MonoBehaviour 
{
	public AudioReader audioReader;
	public float minSpeed;
	public float maxSpeed;
	float speed = 1;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		changespeed ();
	}

	void changespeed ()
	{
		speed = (0.1f*audioReader.amp) + (0.9f*speed);
		speed *= 0.5f;
		speed = Mathf.Pow (speed, 1.25f);
		//speed = Mathf.Log (speed);
		speed = Mathf.Clamp (speed, minSpeed, maxSpeed);
		Debug.Log (speed);

		Time.timeScale = speed;
	}
}
