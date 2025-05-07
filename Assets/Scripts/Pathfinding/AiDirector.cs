using System.Collections.Generic;
using UnityEngine;

using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class AiDirector : MonoBehaviour
{
    public Dijkstra pathFinder;
    public Dijkstra pathFinder2;
    public GridGenerator grid;
    
    void Start()
    {
        grid.GenerateGrid();
        pathFinder.GetAllNodes();
        pathFinder2.GetAllNodes();
        
        Node[] nodes = FindObjectsByType<Node>(FindObjectsSortMode.InstanceID);
        int startNode = nodes.Length - 1;
        int goalNode = Random.Range(0, nodes.Length);

        Stopwatch timer = new Stopwatch();
        timer.Start();
        List<Node> path = pathFinder.FindShortestPath(
            nodes[startNode],
            nodes[goalNode]);
        timer.Stop();
        Debug.Log("pathFinder 1 = " + timer.ElapsedMilliseconds);
        pathFinder.DebugPath(path);
        
        timer = new Stopwatch();
        timer.Start();
        List<Node> path2 = pathFinder2.FindShortestPath(
            nodes[startNode],
            nodes[goalNode]);
        timer.Stop();
        Debug.Log("pathFinder 2 =  " + timer.ElapsedMilliseconds);
        pathFinder2.DebugPath(path2);

        
    }
}
