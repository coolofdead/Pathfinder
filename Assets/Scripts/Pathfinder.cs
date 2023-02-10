using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pathfinder : MonoBehaviour
{
    public delegate void OnPathUpdate(IWalkable currentWalkable, List<IWalkable> visitedWalkables, List<PathNode> walkablesToVisit);
    public OnPathUpdate onPathUpdate;

    private PriorityQueue priorityQueue;
    private List<IWalkable> visitedTile;

    [SerializeField] private bool showCurrentNode = false;
    [SerializeField] private bool showQueue = false;
    [SerializeField] private bool showVisited = false;

    public IEnumerable<IWalkable> FindPath(IWalkable start, IWalkable target)
    {
        priorityQueue = new PriorityQueue();
        visitedTile = new List<IWalkable>();

        SetFirstNode(start);
        PathNode pathNode = FindPath(target);

        // Loop from target to start and store it inside a list
        List<IWalkable> path = new();

        while (pathNode.PreviousNode != null)
        {
            path.Add(pathNode.PreviousNode.Tile);

            pathNode = pathNode.PreviousNode;
        }

        // Reverse it to have the start at the begining of the list
        path.Reverse();

        // Return the path
        return path;
    }

    private PathNode FindPath(IWalkable endNode, PathNode optimalNode = null)
    {
        if (optimalNode?.Tile == endNode || priorityQueue.IsEmpty)
        {
            print("No more nodes to search");
            return optimalNode;
        }

        PathNode currentNode = priorityQueue.GetBestNode();
        if (showCurrentNode) { print("Current node is " + currentNode.Tile); }

        if (currentNode.Tile != endNode)
        {
            visitedTile.Add(currentNode.Tile);

            if (showVisited) { Debug.Log("Visited " + visitedTile.Count); }

            foreach (PathNode pathNode in currentNode.GetTileNeighbours(currentNode))
            {
                if (!visitedTile.Contains(pathNode.Tile)) priorityQueue.AddPathNodeIfNotAlready(pathNode); ;
            }

            if (showQueue) { Debug.Log("Queue " + priorityQueue.Nodes.Count); }

            onPathUpdate?.Invoke(currentNode.Tile, visitedTile, priorityQueue.Nodes);

            optimalNode = FindPath(endNode, optimalNode);

            return optimalNode;
        }
        else
        {
            print("Reach end node");
            return currentNode;
        }
    }

    public void SetFirstNode(IWalkable start)
    {
        PathNode startNode = new PathNode(start);
        priorityQueue.AddPathNodeIfNotAlready(startNode);
    }
}
