using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour, IWalkable
{
    [System.Flags] public enum Direction { None, Right, Left, Forward, Backward }

    public Direction direction = Direction.Right & Direction.Left & Direction.Forward & Direction.Backward;

    public IEnumerable<Tile> NeighbourTiles { get; private set; }
    public Material DefaultColor { get; private set; }

    public MeshRenderer mr;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        DefaultColor = mr.sharedMaterial;
    }

    public void SetNeighbours(IEnumerable<Tile> neighbourTiles)
    {
        NeighbourTiles = neighbourTiles;
    }

    public IEnumerable<IWalkable> GetNeighbours()
    {
        return NeighbourTiles;
    }
}
