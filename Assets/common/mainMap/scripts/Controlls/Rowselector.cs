﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rowselector : MonoBehaviour
{
	private PlayerInputManager playerInputManager;

	private void Start()
    {
		playerInputManager = GameObject.FindObjectOfType<PlayerInputManager>();
		if (playerInputManager != null)
		{
			//Debug.Log(playerInputManager.name + " " + playerInputManager.playerCount);
		}
    }

    private void Update()
    {

	}

	private void OnMove()
	{
		Debug.Log(gameObject.name + ": I'm OnMove");
	}

	private void OnFire()
	{
		//Debug.Log(gameObject.name + ": I'm OnFire");
	}

	private void OnLook()
	{
		//Debug.Log(gameObject.name + ": I'm OnLook");
	}
}
