using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeEdge : MonoBehaviour
{
    public GameObject node1;
    public GameObject node2;
    public LineRenderer lineRenderer;

    private void Update()
    {
        if (node1 != null || node2 != null)
        {
            lineRenderer.SetPosition(0, node1.transform.position);
            lineRenderer.SetPosition(1, node2.transform.position);
        }
    }
}
