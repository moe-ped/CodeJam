using UnityEngine;
using System.Collections;

public class audioTest : MonoBehaviour {

	public float absInput;
	public float amp;
	public float[] smooth = new float[2];
	
	void Start () {
		// initalising the filter
		for (int i = 0; i < 2; i++) {
			smooth [i] = 0.0f;	
		}
	}
	
	// Update is called once per frame
	void Update () {
		//intensity of light, controlled by the amplitude of the sound
		gameObject.GetComponent<Light>().intensity = amp;
	}
	
	void OnAudioFilterRead (float[] data, int channels)
	{		
		for (var i = 0; i < data.Length; i = i + channels) {

			// the absolute value of every sample
			absInput = Mathf.Abs(data[i]);

			// smoothening filter doing its thing
			smooth[0] = ((0.1f * absInput) + (0.99f * smooth[1]));

			// exaggerating the amplitude
			amp = smooth[0]*7;

			// it is a recursive filter, so it is doing its recursive thing
			smooth[1] = smooth[0];
		}
	}
}