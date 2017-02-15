using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerSquare : MonoBehaviour 
{

	public float moveSpeed = 1.0f;				//	How fast the Danger Square moves
	public float speedIncrement = 1.15f;		//	How fast the Danger  square increments speed
	// Use this for initialization
	void Start () 
	{
		
	}
	
	void Move()
	{
		

		Vector3 newPosition = transform.position;
		if (transform.position.y > GameManager.instance.boundaries[0].transform.position.y)
		{
			newPosition = new Vector3( transform.position.x, GameManager.instance.boundaries[0].transform.position.y, transform.position.z);
			moveSpeed = -moveSpeed;
		}
		else if (transform.position.y < GameManager.instance.boundaries[2].transform.position.y)
		{
			newPosition = new Vector3( transform.position.x, GameManager.instance.boundaries[2].transform.position.y, transform.position.z);
			moveSpeed = -moveSpeed;
		}

		if (transform.position.x > GameManager.instance.boundaries[1].transform.position.x)
		{
			newPosition = new Vector3(GameManager.instance.boundaries[1].transform.position.x, transform.position.y ,transform.position.z);
			moveSpeed = -moveSpeed;
		}
		else if (transform.position.x < GameManager.instance.boundaries[3].transform.position.x)
		{
			newPosition = new Vector3(GameManager.instance.boundaries[3].transform.position.x, transform.position.y ,transform.position.z);
			moveSpeed = -moveSpeed;
		}

		transform.position = newPosition;
		
	}

	// Update is called once per frame
	void Update () 
	{
		Move();
		transform.Translate((Vector3.right + Vector3.up) * moveSpeed * Time.deltaTime);
	}
}
