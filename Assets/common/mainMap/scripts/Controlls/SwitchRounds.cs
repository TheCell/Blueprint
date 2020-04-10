using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchRounds : MonoBehaviour
{
	private List<PlayerInput> playerInputs;
	private PlayerInputManager playerManager;


	private void Start()
	{
		playerManager = PlayerInputManager.instance;
		playerManager.onPlayerJoined += PlayerManager_onPlayerJoined;
		playerManager.onPlayerLeft += PlayerManager_onPlayerLeft;
	}

	private void PlayerManager_onPlayerLeft(PlayerInput obj)
	{
		Debug.Log(obj.name + " left");
		throw new System.NotImplementedException();
	}

	private void PlayerManager_onPlayerJoined(PlayerInput obj)
	{
		Debug.Log(obj.name + " joined");
		throw new System.NotImplementedException();
	}

	private void Player_onActionTriggered(InputAction.CallbackContext obj)
	{
		Debug.Log("action triggered");
		Debug.Log(obj.action);
	}

	private void AddPlayerToList()
	{

	}

	private void OnFire()
	{
		Debug.Log(gameObject.name + ": SwitchRounds OnFire");
		SwitchPlayer();
	}

	private void OnMove()
	{
		Debug.Log(gameObject.name + ": SwitchRounds OnMove");
		SwitchPlayer();
	}

	private void SwitchPlayer()
	{
		bool previousWasEnabled = false;
		bool switchedOneOn = false;

		for (int i = 0; i < playerInputs.Count; i++)
		{
			if (previousWasEnabled)
			{
				playerInputs[i].enabled = true;
				previousWasEnabled = false;
				switchedOneOn = true;
			}
			else
			{
				previousWasEnabled = playerInputs[i].enabled;
				playerInputs[i].enabled = false;
			}
		}

		if (!switchedOneOn && playerInputs.Count > 0)
		{
			playerInputs[0].enabled = true;
		}
	}
}
