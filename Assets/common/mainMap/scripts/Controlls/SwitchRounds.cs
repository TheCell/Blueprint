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
		//Debug.Log(input.currentActionMap.actions);
		//input.onActionTriggered += Input_onActionTriggered; // not working for now

		for (int i = 0; i < input.currentActionMap.actions.Count; i++)
		{
			//Debug.Log(input.currentActionMap.actions[i].name);
			if (input.currentActionMap.actions[i].name == "Fire")
			{
				input.currentActionMap.actions[i].performed += SwitchRounds_performed;
			}
		}
		playerInputs.Add(input);
	}

	public void PlayerLeft(PlayerInput input)
	{
		//input.onActionTriggered -= Input_onActionTriggered;
		// TODO remove the listener again
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

	//private void Input_onActionTriggered(InputAction.CallbackContext obj)
	//{
	//	Debug.Log("input action triggered");
	//	Debug.Log(obj.valueType);
	//	SwitchPlayer();
	//  // TODO this should check if a final turn action was performed and switch player
	//}

	private void SwitchRounds_performed(InputAction.CallbackContext obj)
	{
		SwitchPlayer();
	}

	private void SwitchPlayer()
	{
		Debug.Log("Switching player");
		bool previousWasEnabled = false;
		bool switchedOneOn = false;

		for (int i = 0; i < playerInputs.Count; i++)
		{
			if (previousWasEnabled && !switchedOneOn)
			{
				playerInputs[i].ActivateInput();
				previousWasEnabled = false;
				switchedOneOn = true;
			}
			else
			{
				previousWasEnabled = playerInputs[i].inputIsActive;
				playerInputs[i].DeactivateInput();
			}
		}

		if (!switchedOneOn && playerInputs.Count > 0)
		{
			playerInputs[0].ActivateInput();
		}
	}
}
