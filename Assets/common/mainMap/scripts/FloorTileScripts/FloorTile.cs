using UnityEngine;
using System.Collections;

public class FloorTile : MonoBehaviour
{
    private Vector3[] surroundingPositions = new Vector3[4];
    private FloorTile_UnitPlacing[] surroundingTiles = new FloorTile_UnitPlacing[4];



    private void Start()
    {
        Vector3 vecOrigin = transform.position;
        vecOrigin.y -= 0.1f;

        RaycastHit hit;
        RaycastHit[] hits;
        if(Physics.Raycast(vecOrigin, Vector3.forward, out hit, 2.0f))
        {
            surroundingPositions[0] = hit.collider.gameObject.transform.position;
            surroundingTiles[0] = hit.collider.gameObject.GetComponent<FloorTile_UnitPlacing>();
        }
        else
        {
            hits = Physics.RaycastAll(vecOrigin, Vector3.back);
            Vector3 lastElem = transform.position;
            FloorTile_UnitPlacing lastTile = this.GetComponent<FloorTile_UnitPlacing>();

            for(int i = 0; i < hits.Length; i++)
            {
                if(lastElem.z > hits[i].collider.gameObject.transform.position.z)
                {
                    lastElem.z = hits[i].collider.gameObject.transform.position.z;
                    lastTile = hits[i].collider.gameObject.GetComponent<FloorTile_UnitPlacing>();
                }
            }

            surroundingPositions[0] = lastElem;
            surroundingTiles[0] = lastTile;

        }

        if (Physics.Raycast(vecOrigin, Vector3.right, out hit, 2.0f))
        {
            surroundingPositions[1] = hit.collider.gameObject.transform.position;
            surroundingTiles[1] = hit.collider.gameObject.GetComponent<FloorTile_UnitPlacing>();
        }
        else
        {
            hits = Physics.RaycastAll(vecOrigin, Vector3.left);
            Vector3 lastElem = transform.position;
            FloorTile_UnitPlacing lastTile = this.GetComponent<FloorTile_UnitPlacing>();


            for (int i = 0; i < hits.Length; i++)
            {
                if (lastElem.x > hits[i].collider.gameObject.transform.position.x)
                {
                    lastElem.x = hits[i].collider.gameObject.transform.position.x;
                    lastTile = hits[i].collider.gameObject.GetComponent<FloorTile_UnitPlacing>();
                }
            }

            surroundingPositions[1] = lastElem;
            surroundingTiles[1] = lastTile;
        }

        if (Physics.Raycast(vecOrigin, Vector3.back, out hit, 2.0f))
        {
            surroundingPositions[2] = hit.collider.gameObject.transform.position;
            surroundingTiles[2] = hit.collider.gameObject.GetComponent<FloorTile_UnitPlacing>();
        }
        else
        {
            hits = Physics.RaycastAll(vecOrigin, Vector3.forward);
            Vector3 lastElem = transform.position;
            FloorTile_UnitPlacing lastTile = this.GetComponent<FloorTile_UnitPlacing>();

            for (int i = 0; i < hits.Length; i++)
            {
                if (lastElem.z < hits[i].collider.gameObject.transform.position.z)
                {
                    lastElem.z = hits[i].collider.gameObject.transform.position.z;
                    lastTile = hits[i].collider.gameObject.GetComponent<FloorTile_UnitPlacing>();
                }
            }

            surroundingPositions[2] = lastElem;
            surroundingTiles[2] = lastTile;

        }

        if (Physics.Raycast(vecOrigin, Vector3.left, out hit, 2.0f))
        {
            surroundingPositions[3] = hit.collider.gameObject.transform.position;
            surroundingTiles[3] = hit.collider.gameObject.GetComponent<FloorTile_UnitPlacing>();
        }
        else
        {
            hits = Physics.RaycastAll(vecOrigin, Vector3.right);
            Vector3 lastElem = transform.position;
            FloorTile_UnitPlacing lastTile = this.GetComponent<FloorTile_UnitPlacing>();

            for (int i = 0; i < hits.Length; i++)
            {
                if (lastElem.x < hits[i].collider.gameObject.transform.position.x)
                {
                    lastElem.x = hits[i].collider.gameObject.transform.position.x;
                    lastTile = hits[i].collider.gameObject.GetComponent<FloorTile_UnitPlacing>();
                }
            }

            surroundingPositions[3] = lastElem;
            surroundingTiles[3] = lastTile;
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

    public FloorTile_UnitPlacing GetNextPosition(Direction direction, bool returnObject)
    {
        switch (direction)
        {
            case Direction.North:
                return surroundingTiles[0];
            case Direction.East:
                return surroundingTiles[1];
            case Direction.South:
                return surroundingTiles[2];
            case Direction.West:
                return surroundingTiles[3];
            default:
                return null;
        }
    }
}
