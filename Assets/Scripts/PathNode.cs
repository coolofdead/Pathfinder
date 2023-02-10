using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode
{
    public readonly IWalkable Tile;
    public readonly PathNode PreviousNode;

    /// <summary>
    /// Is used to calculate the total tiles used for this tile's path
    /// </summary>
    public int PathValue { get; private set; }

    public IEnumerable<PathNode> GetTileNeighbours(PathNode previousNode)
    {
        foreach(Tile neighbourTile in Tile.GetNeighbours())
        {
            yield return new PathNode(neighbourTile, previousNode, previousNode.PathValue + 1);
        }
    }

    public PathNode (IWalkable tile = null, PathNode previousTile = null, int pathValue = 0)
    {
        Tile = tile;
        PreviousNode = previousTile;
        PathValue = pathValue;
    }
}
