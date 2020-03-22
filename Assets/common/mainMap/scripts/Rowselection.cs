using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rowselection : MonoBehaviour
{
	[SerializeField] private Direction moveDirection;

	private void Start()
    {

	}

    private void Update()
    {

    }

	private void OnMouseEnter()
	{
		HighlightSelection(true);
	}

	private void OnMouseExit()
	{
		HighlightSelection(false);
	}

	private void PushAllObjects()
	{
		RaycastHit[] rayHits;
		Vector3 rayStart = transform.position;
		rayStart.y += 1; // set to middle of the object height

		Ray ray = new Ray(rayStart, -transform.right);
		rayHits = Physics.RaycastAll(ray);
		for (int i = 0; i < rayHits.Length; i++)
		{
			UnitBasics unitBasics = rayHits[i].collider.GetComponent<UnitBasics>();
			if (unitBasics != null)
			{
				unitBasics.MoveToDirection(moveDirection);
			}
		}
	}

	private void HighlightSelection(bool isActive)
	{
		RaycastHit[] rayHits;
		Vector3 rayStart = transform.position;

		Ray ray = new Ray(rayStart, -transform.right);
		rayHits = Physics.RaycastAll(ray);
		for (int i = 0; i < rayHits.Length; i++)
		{
			SelectionHighlight floorToHighlite = rayHits[i].collider.GetComponent<SelectionHighlight>();
			if (floorToHighlite != null)
			{
				floorToHighlite.SetHighlight(isActive);
			}
		}
	}

    private void DamageAllObjects(int dmgAmount)
    {
        RaycastHit[] rayHits;
        Vector3 rayStart = transform.position;
        rayStart.y += 1; // set to middle of the object height

        Ray ray = new Ray(rayStart, -transform.right);
        rayHits = Physics.RaycastAll(ray);
        for (int i = 0; i < rayHits.Length; i++)
        {
            UnitBasics unitBasics = rayHits[i].collider.GetComponent<UnitBasics>();
            if (unitBasics != null)
            {
                unitBasics.TakeDamage(dmgAmount);
            }
        }
    }
}
