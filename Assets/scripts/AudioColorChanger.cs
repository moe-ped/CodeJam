using UnityEngine;
using System.Collections;

public class AudioColorChanger : MonoBehaviour 
{
	public Material[] materials;
	public AudioReader audioReader;

	private Color[] originalColors;
	
	// Use this for initialization
	void Start () 
	{
		setupColors ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		changeColors ();
	}

	void OnApplicationQuit ()
	{
		resetColors ();
	}

	void changeColors ()
	{
		// get audio data
		float leftValue = audioReader.smooth [0];
		//float rightValue = audioReader.smooth [1];

		for (int i=0; i<materials.Length; i++)
		{
			//leftValue -= 1;
			//float clampedLeft = Mathf.Clamp01(leftValue);
			// shift color
			Color newColor = originalColors[i];
			newColor.r += (Mathf.Sin(leftValue*5));
			newColor.g -= (Mathf.Sin(leftValue*5));
			//newColor.b = leftValue;
			materials[i].SetColor("_EmissionColor", newColor);

		}
	}

	void setupColors ()
	{
		originalColors = new Color[materials.Length];
		for (int i=0; i<materials.Length; i++)
		{
			//originalColors[i] = materials[i].color;
			originalColors[i] = materials[i].GetColor("_EmissionColor");
		}
	}

	void resetColors ()
	{
		for (int i=0; i<materials.Length; i++)
		{
			materials[i].SetColor("_EmissionColor", originalColors[i]);
			
		}
	}
}
