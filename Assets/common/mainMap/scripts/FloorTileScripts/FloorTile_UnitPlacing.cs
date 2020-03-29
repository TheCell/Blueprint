using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile_UnitPlacing : MonoBehaviour
{
    SelectionHighlight selection;
    private bool isHovered, isFull = false;

    public Transform prefab;


    private void Start()
    {
        selection = gameObject.GetComponent<SelectionHighlight>();
    }

    private void OnMouseEnter()
    {
        if (selection != null)
        {
            selection.SetHighlight(true);
        }
        isHovered = true;
    }

    private void OnMouseExit()
    {
        if (selection != null)
        {
            selection.SetHighlight(false);
        }
        isHovered = false;
    }


    private void OnFire()
    {
        if (isHovered && !isFull)
        {
            Vector3 spawnPosition = gameObject.transform.position;
            Instantiate(prefab, spawnPosition, Quaternion.Euler(-90, 0, 0));
            isFull = true;
        }
    }
}
