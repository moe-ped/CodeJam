using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed = 5;
	public float jumpHeight = 5;

	private new Rigidbody2D rigidbody;

	private Vector3 jumpforce;
	
	void Start () 
	{
		rigidbody = GetComponent<Rigidbody2D>();
		SetupJumpForce ();
	}

	void Update () 
	{
		move ();
		if (Input.GetButtonDown ("Jump"))
		{
			jump ();
		}
		checkDeath ();
	}

	private void move ()
	{
		transform.position += Vector3.right * Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
	}

	private void jump ()
	{
		rigidbody.AddForce (Vector2.up*10, ForceMode2D.Impulse);
	}

	private void checkDeath ()
	{
		if (Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 0.5f).y < 0 || Camera.main.WorldToScreenPoint(transform.position - Vector3.up * 0.5f).y > Screen.height)
		{
			// TODO: show gameover message
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	private void SetupJumpForce()
	{
		// calculate jump force from jump height and gravity
		float vy = Mathf.Pow (2*Mathf.Abs(Physics.gravity.y)*jumpHeight, 0.5f);
		jumpforce = Vector3.up * vy;
	}
}
