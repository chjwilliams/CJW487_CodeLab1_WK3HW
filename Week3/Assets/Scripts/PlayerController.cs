using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*--------------------------------------------------------------------------------------*/
/*																						*/
/*	PlayerController: Controls player 			     									*/
/*			Functions:																	*/
/*					public:																*/
/*						                        										*/
/*					proteceted:															*/
/*                                                                                      */
/*					private:															*/
/*						void Start ()													*/
/*						void Move (KeyCode key)											*/
/*						void CheckBoundary ()											*/
/*						void OnCollisionEnter2D (Collider2D other)						*/
/*						void Update ()													*/
/*																						*/
/*--------------------------------------------------------------------------------------*/
public class PlayerController : MonoBehaviour 
{

	//	Public variables
	public float moveSpeed = 5.0f;				//	How fast the player moves
	public KeyCode upKey = KeyCode.W;			//	Input for moving up
	public KeyCode downKey = KeyCode.S;			//	Input for moving down
	public KeyCode rightKey = KeyCode.D;		//	Input for moving right
	public KeyCode leftKey = KeyCode.A;			//	Input for moving left

    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Start: Runs once at the begining of the game. Initalizes variables.					*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
	void Start () 
	{
		
	}

    /*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Move: Moves player left, right, up, and/or down based on input						*/
    /*		param: KeyCode key - the key that was pressed									*/
	/*																						*/
    /*--------------------------------------------------------------------------------------*/
	void Move (KeyCode key)
	{
		if (Input.GetKey(upKey))
		{
			transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
		}
		else if (Input.GetKey(downKey))
		{
			transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKey(rightKey))
		{
			transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
		}
		else if (Input.GetKey(leftKey))
		{
			transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
		}

		CheckBoundary();
	}

	void CheckBoundary()
	{
		Vector3 newPosition = transform.position;
		if (transform.position.y > GameManager.instance.boundaries[0].transform.position.y)
		{
			newPosition = new Vector3( transform.position.x, GameManager.instance.boundaries[0].transform.position.y, transform.position.z);
		}
		else if (transform.position.y < GameManager.instance.boundaries[2].transform.position.y)
		{
			newPosition = new Vector3( transform.position.x, GameManager.instance.boundaries[2].transform.position.y, transform.position.z);
		}

		if (transform.position.x > GameManager.instance.boundaries[1].transform.position.x)
		{
			newPosition = new Vector3(GameManager.instance.boundaries[1].transform.position.x, transform.position.y ,transform.position.z);
		}
		else if (transform.position.x < GameManager.instance.boundaries[3].transform.position.x)
		{
			newPosition = new Vector3(GameManager.instance.boundaries[3].transform.position.x, transform.position.y ,transform.position.z);
		}

		transform.position = newPosition;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name.Contains("Boundary"))
		{
			moveSpeed = -moveSpeed;
		}
	}
	
	/*--------------------------------------------------------------------------------------*/
    /*																						*/
    /*	Update: Called once per frame														*/
    /*																						*/
    /*--------------------------------------------------------------------------------------*/
	void Update () 
	{
		Move (upKey);
		Move (downKey);
		Move (leftKey);
		Move (rightKey);
	}
}
