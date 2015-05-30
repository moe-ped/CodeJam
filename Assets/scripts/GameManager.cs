using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{

	public float score;
	public Text scoreText;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		updateScoreText ();
	}

	void updateScoreText ()
	{
		scoreText.text = score.ToString ();
	}
}
