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
/*						void Update ()													*/
/*																						*/
/*--------------------------------------------------------------------------------------*/
public class PlayerController : MonoBehaviour 
{

	//	Public variables
	public float moveSpeed = 5.0f;
	public KeyCode upKey = KeyCode.W;
	public KeyCode downKey = KeyCode.S;
	public KeyCode rightKey = KeyCode.D;
	public KeyCode leftKey = KeyCode.A;

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
