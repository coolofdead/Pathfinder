using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PriorityQueue
{
    private List<PathNode> nodes = new List<PathNode>();
    public List<PathNode> Nodes => nodes;

    public bool IsEmpty => Nodes.Count == 0;

    public PathNode GetBestNode()
    {
        PathNode bestPathNode = Nodes.OrderBy(node => node.PathValue).First();
        Nodes.Remove(bestPathNode);

        return bestPathNode;
    }

    public void AddPathNodeIfNotAlready(PathNode pathNode)
    {
        for (int i = 0; i < nodes.Count; i++)
        {
            if (nodes[i].Tile == pathNode.Tile)
            {
                return;
            }
        }

        nodes.Add(pathNode);
    }
}
