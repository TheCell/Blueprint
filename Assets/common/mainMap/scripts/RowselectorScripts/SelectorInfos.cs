using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rowselection))]
public class SelectorInfos : MonoBehaviour
{
	private SelectorInfos leftSelector;
	private SelectorInfos rightSelector;
	private Rowselection objectSelector;

	public SelectorInfos GetLeftSelector()
	{
		return leftSelector;
	}

	public SelectorInfos GetRightSelector()
	{
		return rightSelector;
	}

	public Rowselection GetRowselection()
	{
		return objectSelector;
	}

	private void Start()
    {
		objectSelector = gameObject.GetComponent<Rowselection>();
		PopulateNeighbours();
	}

	private void PopulateNeighbours()
	{
		leftSelector = GetSelector(false);
		rightSelector = GetSelector(true);
	}

	private SelectorInfos GetSelector(bool getRightSelector)
	{
		SelectorInfos leftSelector;
		// no other selectors found, taking myself as reference
		leftSelector = this;

		RaycastHit rayHit;
		Vector3 origin = transform.position;
		origin.y += 1;
		origin.z += 1;
		Vector3 normalCheck = -transform.forward;
		Vector3 angleCheck = (-transform.forward - transform.right).normalized;
		if (getRightSelector)
		{
			normalCheck = transform.forward;
			angleCheck = (transform.forward + transform.right).normalized;
		}

		if (Physics.Raycast(new Ray(origin, normalCheck), out rayHit)) // check left same column
		{
			SelectorInfos leftSelectorInfo = rayHit.collider.gameObject.GetComponent<SelectorInfos>();
			if (leftSelectorInfo != null)
			{
				leftSelector = leftSelectorInfo;
			}
			else
			{
				Debug.LogError("found object but is not SelectorInfos");
			}
		}
		else if (Physics.Raycast(new Ray(origin, angleCheck), out rayHit)) // check diagonal because it's the end of the row
		{
			SelectorInfos leftSelectorInfo = rayHit.collider.gameObject.GetComponent<SelectorInfos>();
			if (leftSelectorInfo != null)
			{
				leftSelector = leftSelectorInfo;
			}
			else
			{
				Debug.LogError("found object but is not SelectorInfos");
			}
		}

		return leftSelector;
	}

}
