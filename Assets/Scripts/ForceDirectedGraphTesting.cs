using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EpForceDirectedGraph.cs;

public class ForceDirectedGraphTesting : MonoBehaviour
{
    [Range(1, 100)]
    public float stiffness = 81;

    [Range(1, 1000)]
    public float repulsion = 500;

    [Range(0, 1)]
    public float damping = 0.5f;

    [Range(0, 10)]
    public float threadshold = 0.5f;

    [Range(1, 1000)]
    public int numberOfNodes = 50;

    private Renderer graphRenderer = null;

    public void CreateGraph()
    {
        Graph graph = new Graph();

        List<NodeData> nodeDatas = new List<NodeData>();

        for (int i = 0; i <= numberOfNodes; i++)
        {
            NodeData data = new NodeData
            {
                label = $"Node_{i.ToString()}"
            };
            nodeDatas.Add(data);
        }

        graph.CreateNodes(nodeDatas);

        List<Triple<string, string, EdgeData>> edges = new List<Triple<string, string, EdgeData>>
        {
            new Triple<string, string, EdgeData>("3", "13", new EdgeData { label = "Edge_3_13" }),
            new Triple<string, string, EdgeData>("3", "49", new EdgeData { label = "Edge_3_49" }),
            new Triple<string, string, EdgeData>("4", "20", new EdgeData { label = "Edge_4_20" }),
            new Triple<string, string, EdgeData>("4", "28", new EdgeData { label = "Edge_4_28" }),
            new Triple<string, string, EdgeData>("4", "36", new EdgeData { label = "Edge_4_36" }),
            new Triple<string, string, EdgeData>("5", "9", new EdgeData { label = "Edge_5_9" }),
            new Triple<string, string, EdgeData>("5", "25", new EdgeData { label = "Edge_5_25" }),
            new Triple<string, string, EdgeData>("5", "46", new EdgeData { label = "Edge_5_46" }),
            new Triple<string, string, EdgeData>("7", "4", new EdgeData { label = "Edge_7_4" }),
            new Triple<string, string, EdgeData>("8", "33", new EdgeData { label = "Edge_8_33" }),
            new Triple<string, string, EdgeData>("10", "42", new EdgeData { label = "Edge_10_42" }),
            new Triple<string, string, EdgeData>("12", "18", new EdgeData { label = "Edge_12_18" }),
            new Triple<string, string, EdgeData>("12", "30", new EdgeData { label = "Edge_12_30" }),
            new Triple<string, string, EdgeData>("12", "48", new EdgeData { label = "Edge_12_48" }),
            new Triple<string, string, EdgeData>("13", "21", new EdgeData { label = "Edge_13_21" }),
            new Triple<string, string, EdgeData>("15", "8", new EdgeData { label = "Edge_15_8" }),
            new Triple<string, string, EdgeData>("15", "32", new EdgeData { label = "Edge_15_32" }),
            new Triple<string, string, EdgeData>("16", "28", new EdgeData { label = "Edge_16_28" }),
            new Triple<string, string, EdgeData>("16", "41", new EdgeData { label = "Edge_16_41" }),
            new Triple<string, string, EdgeData>("17", "5", new EdgeData { label = "Edge_17_5" }),
            new Triple<string, string, EdgeData>("17", "7", new EdgeData { label = "Edge_17_7" }),
            new Triple<string, string, EdgeData>("17", "40", new EdgeData { label = "Edge_17_40" }),
            new Triple<string, string, EdgeData>("17", "41", new EdgeData { label = "Edge_17_41" }),
            new Triple<string, string, EdgeData>("18", "5", new EdgeData { label = "Edge_18_5" }),
            new Triple<string, string, EdgeData>("18", "29", new EdgeData { label = "Edge_18_29" }),
            new Triple<string, string, EdgeData>("19", "25", new EdgeData { label = "Edge_19_25" }),
            new Triple<string, string, EdgeData>("20", "15", new EdgeData { label = "Edge_20_15" }),
            new Triple<string, string, EdgeData>("20", "19", new EdgeData { label = "Edge_20_19" }),
            new Triple<string, string, EdgeData>("20", "48", new EdgeData { label = "Edge_20_48" }),
            new Triple<string, string, EdgeData>("20", "49", new EdgeData { label = "Edge_20_49" }),
            new Triple<string, string, EdgeData>("21", "14", new EdgeData { label = "Edge_21_14" }),
            new Triple<string, string, EdgeData>("21", "23", new EdgeData { label = "Edge_21_23" }),
            new Triple<string, string, EdgeData>("22", "39", new EdgeData { label = "Edge_22_39" }),
            new Triple<string, string, EdgeData>("23", "1", new EdgeData { label = "Edge_23_1" }),
            new Triple<string, string, EdgeData>("23", "18", new EdgeData { label = "Edge_23_18" }),
            new Triple<string, string, EdgeData>("23", "26", new EdgeData { label = "Edge_23_26" }),
            new Triple<string, string, EdgeData>("23", "38", new EdgeData { label = "Edge_23_38" }),
            new Triple<string, string, EdgeData>("24", "47", new EdgeData { label = "Edge_24_47" }),
            new Triple<string, string, EdgeData>("26", "14", new EdgeData { label = "Edge_26_14" }),
            new Triple<string, string, EdgeData>("27", "12", new EdgeData { label = "Edge_27_12" }),
            new Triple<string, string, EdgeData>("27", "47", new EdgeData { label = "Edge_27_47" }),
            new Triple<string, string, EdgeData>("30", "3", new EdgeData { label = "Edge_30_3" }),
            new Triple<string, string, EdgeData>("30", "44", new EdgeData { label = "Edge_30_44" }),
            new Triple<string, string, EdgeData>("31", "35", new EdgeData { label = "Edge_31_35" }),
            new Triple<string, string, EdgeData>("31", "40", new EdgeData { label = "Edge_31_40" }),
            new Triple<string, string, EdgeData>("33", "27", new EdgeData { label = "Edge_33_27" }),
            new Triple<string, string, EdgeData>("34", "6", new EdgeData { label = "Edge_34_6" }),
            new Triple<string, string, EdgeData>("34", "15", new EdgeData { label = "Edge_34_15" }),
            new Triple<string, string, EdgeData>("35", "17", new EdgeData { label = "Edge_35_17" }),
            new Triple<string, string, EdgeData>("35", "31", new EdgeData { label = "Edge_35_31" }),
            new Triple<string, string, EdgeData>("35", "41", new EdgeData { label = "Edge_35_41" }),
            new Triple<string, string, EdgeData>("36", "14", new EdgeData { label = "Edge_36_14" }),
            new Triple<string, string, EdgeData>("37", "1", new EdgeData { label = "Edge_37_1" }),
            new Triple<string, string, EdgeData>("37", "15", new EdgeData { label = "Edge_37_15" }),
            new Triple<string, string, EdgeData>("37", "25", new EdgeData { label = "Edge_37_25" }),
            new Triple<string, string, EdgeData>("38", "15", new EdgeData { label = "Edge_38_15" }),
            new Triple<string, string, EdgeData>("38", "18", new EdgeData { label = "Edge_38_18" }),
            new Triple<string, string, EdgeData>("38", "44", new EdgeData { label = "Edge_38_44" }),
            new Triple<string, string, EdgeData>("39", "6", new EdgeData { label = "Edge_39_6" }),
            new Triple<string, string, EdgeData>("39", "36", new EdgeData { label = "Edge_39_36" }),
            new Triple<string, string, EdgeData>("39", "49", new EdgeData { label = "Edge_39_49" }),
            new Triple<string, string, EdgeData>("41", "5", new EdgeData { label = "Edge_41_5" }),
            new Triple<string, string, EdgeData>("41", "6", new EdgeData { label = "Edge_41_6" }),
            new Triple<string, string, EdgeData>("41", "17", new EdgeData { label = "Edge_41_17" }),
            new Triple<string, string, EdgeData>("41", "46", new EdgeData { label = "Edge_41_46" }),
            new Triple<string, string, EdgeData>("42", "18", new EdgeData { label = "Edge_42_18" }),
            new Triple<string, string, EdgeData>("42", "40", new EdgeData { label = "Edge_42_40" }),
            new Triple<string, string, EdgeData>("42", "46", new EdgeData { label = "Edge_42_46" }),
            new Triple<string, string, EdgeData>("43", "12", new EdgeData { label = "Edge_43_12" }),
            new Triple<string, string, EdgeData>("43", "22", new EdgeData { label = "Edge_43_22" }),
            new Triple<string, string, EdgeData>("43", "26", new EdgeData { label = "Edge_43_26" }),
            new Triple<string, string, EdgeData>("43", "39", new EdgeData { label = "Edge_43_39" }),
            new Triple<string, string, EdgeData>("44", "37", new EdgeData { label = "Edge_44_37" }),
            new Triple<string, string, EdgeData>("45", "19", new EdgeData { label = "Edge_45_19" }),
            new Triple<string, string, EdgeData>("45", "49", new EdgeData { label = "Edge_45_49" }),
            new Triple<string, string, EdgeData>("47", "2", new EdgeData { label = "Edge_47_2" }),
            new Triple<string, string, EdgeData>("47", "11", new EdgeData { label = "Edge_47_11" }),
            new Triple<string, string, EdgeData>("47", "41", new EdgeData { label = "Edge_47_41" }),
            new Triple<string, string, EdgeData>("48", "11", new EdgeData { label = "Edge_48_11" }),
            new Triple<string, string, EdgeData>("48", "40", new EdgeData { label = "Edge_48_40" }),
            new Triple<string, string, EdgeData>("48", "46", new EdgeData { label = "Edge_48_46" }),
            new Triple<string, string, EdgeData>("49", "0", new EdgeData { label = "Edge_49_0" }),
            new Triple<string, string, EdgeData>("49", "17", new EdgeData { label = "Edge_49_17" }),
            new Triple<string, string, EdgeData>("49", "37", new EdgeData { label = "Edge_49_37" })
        };

        graph.CreateEdges(edges);

        ForceDirected3D m_fdgPhysics = new ForceDirected3D(graph, stiffness, repulsion, damping);
        m_fdgPhysics.Threadshold = threadshold;

        if (graphRenderer != null)
        {
            graphRenderer.Clear();
        }

        graphRenderer = new Renderer(m_fdgPhysics);

        foreach (var edge in graph.edges)
        {
            Debug.Log(edge.ToString());
        }

        //float timeStep = 0.05f;
        //graphRenderer.Draw(timeStep);
    }

    private void Update()
    {
        if (graphRenderer != null)
        {
            graphRenderer.Draw(0.05f);
        }
    }

    private class Renderer : AbstractRenderer
    {
        private List<GameObject> gameObjects = new List<GameObject>();

        public Renderer(IForceDirected iForceDirected) : base(iForceDirected)
        {
            Transform graphHolder = GameObject.FindWithTag("Graph").transform;
            GameObject nodePrefab = Resources.Load("Node") as GameObject;
            GameObject edgePrefab = Resources.Load("Edge") as GameObject;

            foreach (Node n in iForceDirected.graph.nodes)
            {
                //GameObject nodeObj = Instantiate(Resources.Load("Node") as GameObject, new Vector3(n.Data.initialPostion.x, n.Data.initialPostion.y, n.Data.initialPostion.z), Quaternion.identity, graphHolder);
                GameObject nodeObj = Instantiate(nodePrefab, graphHolder);
                nodeObj.name = n.Data.label;

                // Passing the value of the underlying node to the 'Interface' between the GameObject and the actual FDG object

                var na = nodeObj.GetComponent<NodeAssociation>();
                na._associatedNode = n;
                n.associatedNodeObject = na;
                n.Data.gameObject = nodeObj;
                gameObjects.Add(nodeObj);
            }

            foreach (Edge e in iForceDirected.graph.edges)
            {
                GameObject edgeObj = Instantiate(edgePrefab, graphHolder);
                edgeObj.name = e.Data.label;
                NodeEdge nodeEdge = edgeObj.GetComponent<NodeEdge>();
                nodeEdge.node1 = e.Source.Data.gameObject;
                nodeEdge.node2 = e.Target.Data.gameObject;
                gameObjects.Add(edgeObj);
            }
        }

        public override void Clear()
        {
            // Clear previous drawing if needed
            // will be called when AbstractRenderer:Draw is called

            foreach (GameObject gameObject in gameObjects)
            {
                Destroy(gameObject);
            }
        }

        protected override void drawEdge(Edge iEdge, AbstractVector iPosition1, AbstractVector iPosition2)
        {
            // Draw the given edge according to given positions

            //LineRenderer lineRenderer = GetComponent<LineRenderer>();
            //lineRenderer.SetPosition(0, new Vector3(iPosition1.x, iPosition1.y, iPosition1.z));
            //lineRenderer.SetPosition(1, new Vector3(iPosition2.x, iPosition2.y, iPosition2.z));

            //GameObject edgeObj = Instantiate(Resources.Load("Edge") as GameObject, Vector3.zero, Quaternion.identity, graphHolder);
            //NodeEdge nodeEdge = edgeObj.GetComponent<NodeEdge>();
            //nodeEdge.node1 = new Vector3(iPosition1.x, iPosition1.y, iPosition1.z);
            //nodeEdge.node2 = new Vector3(iPosition2.x, iPosition2.y, iPosition2.z);

            //LineRenderer lineRenderer = edgeObj.GetComponent<LineRenderer>();
            //lineRenderer.SetPosition(0, nodeEdge.node1);
            //lineRenderer.SetPosition(1, nodeEdge.node2);
        }

        protected override void drawNode(Node iNode, AbstractVector iPosition)
        {
            // Draw the given node according to given position
            //GameObject nodeObj = Instantiate(Resources.Load("Node") as GameObject, new Vector3(iPosition.x, iPosition.y, iPosition.z), Quaternion.identity, graphHolder);
            //nodeObj.name = iNode.Data.label;
            iNode.Data.gameObject.transform.position = new Vector3(iPosition.x, iPosition.y, iPosition.z);
        }
    };
}