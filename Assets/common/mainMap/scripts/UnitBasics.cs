using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBasics : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

	public void MoveToDirection(Direction moveTo)
	{
		RaycastHit rayhit;
		Vector3 newposition = Vector3.zero;

		Vector3 objectMiddle = transform.position;
		objectMiddle.y += 1; // object middle
		if (Physics.Raycast(objectMiddle, Vector3.down, out rayhit))
		{
			FloorTile floorTile = rayhit.collider.GetComponent<FloorTile>();
			if (floorTile != null)
			{
				newposition = floorTile.GetNextPosition(moveTo);
			}
		}
		else
		{
			Debug.LogError("no floor tile");
		}

		transform.position = newposition;
	}
}
