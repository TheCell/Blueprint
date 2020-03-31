using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rowselection : MonoBehaviour
{
	[SerializeField] private Direction moveDirection;
	[SerializeField] private bool isSelected;
	[SerializeField] private SelectionHighlight[] highlightParts;
	private SelectorInfos selectorInfos;

	public bool IsSelected
	{
		get
		{
			return isSelected;
		}
		set
		{
			isSelected = value;
			if (value)
			{
				HighlightSelection(true);
			}
			else
			{
				HighlightSelection(false);
			}
		}
	}

	private void Start()
	{
		selectorInfos = gameObject.GetComponent<SelectorInfos>();
	}

	private void OnMouseEnter()
	{
		IsSelected = true;
	}

	private void OnMouseExit()
	{
		IsSelected = false;
	}

	private void OnMove(InputValue value)
	{
		if (!IsSelected)
		{
			return;
		}

		Vector2 direction = value.Get<Vector2>();

		if (direction.x > 0.1f)
		{
			IsSelected = false;
			SelectorInfos rightSelector = selectorInfos.GetRightSelector();
			rightSelector.GetRowselection().IsSelected = true;
		}
		else if (direction.x < -0.1f)
		{
			IsSelected = false;
			SelectorInfos leftSelector = selectorInfos.GetLeftSelector();
			leftSelector.GetRowselection().IsSelected = true;
		}
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

		// highlight selector parts
		for (int i = 0; i < highlightParts.Length; i++)
		{
			highlightParts[i].SetHighlight(isActive);
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
