using UnityEngine;
using System.Collections;

public class FloorTile : MonoBehaviour
{
    private Vector3[] surroundingPositions = new Vector3[4];

    private void Start()
    {
        Vector3 vecOrigin = transform.position;
        vecOrigin.y -= 0.1f;

        RaycastHit hit;
        RaycastHit[] hits;
        if(Physics.Raycast(vecOrigin, Vector3.forward, out hit, 2.0f))
        {
            surroundingPositions[0] = hit.collider.gameObject.transform.position;
        }
        else
        {
            hits = Physics.RaycastAll(vecOrigin, Vector3.back);
            Vector3 lastElem = transform.position;

            for(int i = 0; i < hits.Length; i++)
            {
                if(lastElem.z > hits[i].collider.gameObject.transform.position.z)
                {
                    lastElem.z = hits[i].collider.gameObject.transform.position.z;
                }
            }

            surroundingPositions[0] = lastElem;


        }

        if (Physics.Raycast(vecOrigin, Vector3.right, out hit, 2.0f))
        {
            surroundingPositions[1] = hit.collider.gameObject.transform.position;
        }
        else
        {
            hits = Physics.RaycastAll(vecOrigin, Vector3.left);
            Vector3 lastElem = transform.position;

            for (int i = 0; i < hits.Length; i++)
            {
                if (lastElem.x > hits[i].collider.gameObject.transform.position.x)
                {
                    lastElem.x = hits[i].collider.gameObject.transform.position.x;
                }
            }

            surroundingPositions[1] = lastElem;

        }

        if (Physics.Raycast(vecOrigin, Vector3.back, out hit, 2.0f))
        {
            surroundingPositions[2] = hit.collider.gameObject.transform.position;
        }
        else
        {
            hits = Physics.RaycastAll(vecOrigin, Vector3.forward);
            Vector3 lastElem = transform.position;

            for (int i = 0; i < hits.Length; i++)
            {
                if (lastElem.z < hits[i].collider.gameObject.transform.position.z)
                {
                    lastElem.z = hits[i].collider.gameObject.transform.position.z;
                }
            }

            surroundingPositions[2] = lastElem;

        }

        if (Physics.Raycast(vecOrigin, Vector3.left, out hit, 2.0f))
        {
            surroundingPositions[3] = hit.collider.gameObject.transform.position;
        }
        else
        {
            hits = Physics.RaycastAll(vecOrigin, Vector3.right);
            Vector3 lastElem = transform.position;

            for (int i = 0; i < hits.Length; i++)
            {
                if (lastElem.x < hits[i].collider.gameObject.transform.position.x)
                {
                    lastElem.x = hits[i].collider.gameObject.transform.position.x;
                }
            }

            surroundingPositions[3] = lastElem;
		}
	}

    public Vector3 GetNextPosition(Direction direction)
    {
		switch (direction)
        {
            case Direction.North:
                return surroundingPositions[0];
            case Direction.East:
                return surroundingPositions[1];
            case Direction.South:
				return surroundingPositions[2];
            case Direction.West:
                return surroundingPositions[3];
            default:
                return Vector3.zero;
        }
    }
}
