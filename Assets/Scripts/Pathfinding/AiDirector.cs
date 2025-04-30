using System.Collections.Generic;
using UnityEngine;

public class AiDirector : MonoBehaviour
{
    public Dijkstra pathFinder;
    public GridGenerator grid;
    
    void Start()
    {
       
        grid.GenerateGrid();
        
        pathFinder.GetAllNodes();

        Node[] nodes = FindObjectsByType<Node>(FindObjectsSortMode.InstanceID);
        
        List<Node> path = pathFinder.FindShortestPath(
            nodes[nodes.Length-1],
            nodes[Random.Range(0,nodes.Length)]);
        Debug.Log(path.Count);
        pathFinder.DebugPath(path);
    }

    void Update()
    {
        
    }
}
