using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rowselection : MonoBehaviour
{
	[SerializeField] private Direction moveDirection;
	private bool donThis = false;

	private void Start()
    {
		
	}

    private void Update()
    {
        while (!donThis)
		{
			donThis = true;
            PushAllObjects();
            //DamageAllObjects(1);
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
