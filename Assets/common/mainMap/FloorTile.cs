using UnityEngine;
using System.Collections;

public class FloorTile : MonoBehaviour
{
    private Vector3[] surroundingPositions = new Vector3[4];

    private void Start()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position ,Vector3.forward, out hit, 2.0f))
        {
            surroundingPositions[0] = hit.collider.gameObject.transform.position;
        }
        if (Physics.Raycast(transform.position, Vector3.right, out hit, 2.0f))
        {
            surroundingPositions[1] = hit.collider.gameObject.transform.position;
        }
        if (Physics.Raycast(transform.position, Vector3.back, out hit, 2.0f))
        {
            surroundingPositions[2] = hit.collider.gameObject.transform.position;
        }
        if (Physics.Raycast(transform.position, Vector3.left, out hit, 2.0f))
        {
            surroundingPositions[3] = hit.collider.gameObject.transform.position;
        }
    }

    public Vector3 GetNextPosition(Direction direction)
    {
        switch(direction)
        {
            case Direction.North:
                return surroundingPositions[0];
                break;
            case Direction.East:
                return surroundingPositions[1];
                break;
            case Direction.South:
                return surroundingPositions[2];
                break;
            case Direction.West:
                return surroundingPositions[3];
                break;
            default:
                return Vector3.zero;
                break;
        }
    }
}
