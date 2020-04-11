using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchRounds : MonoBehaviour
{
	private List<PlayerInput> playerInputs;
	private PlayerInputManager playerManager;


	public void PlayerJoined(PlayerInput input)
	{
		input.onActionTriggered += Input_onActionTriggered;
		playerInputs.Add(input);
	}

	public void PlayerLeft(PlayerInput input)
	{
		input.onActionTriggered -= Input_onActionTriggered;
		playerInputs.Remove(input);
	}

	private void Start()
	{
		playerManager = PlayerInputManager.instance;
		playerInputs = new List<PlayerInput>();
		// use manual reference until unity fixed this
		//playerManager.onPlayerJoined += PlayerManager_onPlayerJoined;
		//playerManager.onPlayerLeft += PlayerManager_onPlayerLeft;
	}

	private void Update()
	{
		//for (int i = 0; i < playerInputs.Count; i++)
		//{
		//	Debug.Log(playerInputs[i].actions);
		//}
	}

	private void Input_onActionTriggered(InputAction.CallbackContext obj)
	{
		Debug.Log("input action triggered");
		Debug.Log(obj.valueType);
		SwitchPlayer();
		// TODO this should check if a final turn action was performed and switch player
		//throw new System.NotImplementedException();
	}

	private void SwitchPlayer()
	{
		bool previousWasEnabled = false;
		bool switchedOneOn = false;

		for (int i = 0; i < playerInputs.Count; i++)
		{
			if (previousWasEnabled && !switchedOneOn)
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
