using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(FloorTile))]
public class FloorTile_UnitPlacing : MonoBehaviour
{
    SelectionHighlight selection;
    [SerializeField] private Direction moveDirection;

    private bool isSelected, isFull = false;
    FloorTile floorTile;

    public Transform prefab;


    private void Start()
    {
        selection = gameObject.GetComponent<SelectionHighlight>();
        floorTile = gameObject.GetComponent<FloorTile>();
    }

    private void OnMouseEnter()
    {
        if (selection != null)
        {
            selection.SetHighlight(true);
        }
        isSelected = true;
    }

    private void OnMouseExit()
    {
        if (selection != null)
        {
            selection.SetHighlight(false);
        }
        isSelected = false;
    }

    private void OnMove(InputValue inputValue)
    {
        //Debug.Log("FloorTile" + inputValue.Get<Vector2>());
        Vector2 dir = inputValue.Get<Vector2>();
        FloorTile_UnitPlacing next;


        if (isSelected)
        {
            if (dir.x <= -0.1)
            {
                Debug.Log("WEST");
                moveDirection = Direction.West;
                next = floorTile.GetNextPosition(moveDirection,true);
                next.SetHighlight(true);
                next.isSelected = true;
                SetHighlight(false);
                isSelected = false;
            }
            else if (dir.x >= 0.1)
            {
                Debug.Log("EAST");
                moveDirection = Direction.East;
                next = floorTile.GetNextPosition(moveDirection, true);
                next.SetHighlight(true);
                next.isSelected = true;
                SetHighlight(false);
                isSelected = false;

            }
            else if (dir.y <= -0.1)
            {
                Debug.Log("SOUTH");
                moveDirection = Direction.South;
                next = floorTile.GetNextPosition(moveDirection, true);
                next.SetHighlight(true);
                next.isSelected = true;
                SetHighlight(false);
                isSelected = false;

            }
            else if (dir.y >= 0.1)
            {
                Debug.Log("NORTH");
                moveDirection = Direction.North;
                next = floorTile.GetNextPosition(moveDirection, true);
                next.SetHighlight(true);
                next.isSelected = true;
                SetHighlight(false);
                isSelected = false;

            }
            else
            {
                Debug.Log("Threshold not met");
                //next = this;
            }
        }
    }

    private void OnFire()
    {
        if (isSelected && !isFull)
        {
            Vector3 spawnPosition = gameObject.transform.position;
            Instantiate(prefab, spawnPosition, Quaternion.Euler(-90, 0, 0));
            isFull = true;
        }
    }

    public void SetHighlight(bool highlight)
    {
        selection.SetHighlight(highlight);
    }
}
