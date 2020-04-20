using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EpForceDirectedGraph.cs;

public class NodeAssociation : MonoBehaviour
{
    public Node _associatedNode;
    public string positionString;
    public string pointPosition;

    [HideInInspector]
    public bool associatedNodePinned = false;

    private void Update()
    {
        var gameObjectTransform = this.gameObject.transform.position;
        positionString = gameObjectTransform.ToString();

        // Set the position of the node
        if (_associatedNode.status == nodeStatus.held)
        {
            _associatedNode.pt.position.x = gameObjectTransform.x;
            _associatedNode.pt.position.y = gameObjectTransform.y;
            _associatedNode.pt.position.z = gameObjectTransform.z;
        }
        // The object which will be printed to the screen
        var positionObject = _associatedNode.pt.position;

        pointPosition = "(" + positionObject.x.ToString() + "," + positionObject.y.ToString() + "," + positionObject.z.ToString() + ")";
    }

    public void pinNode()
    {
        // Checks to see if the node is held.
        if (!associatedNodePinned)
        {
            // Node is currently free
            _associatedNode.status = nodeStatus.held;
        }
        else
        {
            // Node is currently being held
            _associatedNode.status = nodeStatus.free;
        }

        // Flips the value of the bool
        associatedNodePinned = !associatedNodePinned;

        Debug.Log("Node pinning is now: " + _associatedNode.Pinned.ToString());
    }
}