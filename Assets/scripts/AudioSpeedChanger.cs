using UnityEngine;
using System.Collections;

public class AudioSpeedChanger : MonoBehaviour 
{
	public AudioReader audioReader;
	public float minSpeed;
	public float maxSpeed;
	public float amplitudeMultiplier = 1;
	public float speedEccentricity = 1.25f;

	private float speed = 1;

	void Update () 
	{
		changespeed ();
	}

	void changespeed ()
	{
		speed = (0.1f*audioReader.amp*amplitudeMultiplier) + (0.9f*speed);
		speed *= 0.5f;
		speed = Mathf.Pow (speed, speedEccentricity);
		//speed = Mathf.Log (speed);
		speed = Mathf.Clamp (speed, minSpeed, maxSpeed);

		Time.timeScale = speed;
	}
}
