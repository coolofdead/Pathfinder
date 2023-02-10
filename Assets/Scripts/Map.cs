using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Map : MonoBehaviour, IPathFindable
{
    public delegate void OnPathFind(IWalkable start, IWalkable end);
    public static OnPathFind onPathFind;

    public Vector2Int startPos;
    public Vector2Int endPos;

    public Pathfinder Pathfinder;
    public TileMaterialController tmc;

    public int xSize;
    public int ySize;

    public Tile[,] Grid { get; private set; }

    void Start()
    {
        SetupMap(transform.GetComponentsInChildren<Tile>());

        onPathFind(GetTileAt(startPos), GetTileAt(endPos));

        IEnumerable<IWalkable> path = Pathfinder.FindPath(GetTileAt(startPos), GetTileAt(endPos));
        LoadFinalPath(path);
    }

    public void LoadFinalPath(IEnumerable<IWalkable> path)
    {
        foreach (Tile tile in path)
        {
            tile.mr.material = tmc.frontierMaterial;
        }
    }

    public Tile GetTileAt(Vector2Int pos)
    {
        return Grid[pos.y, pos.x];
    }

    public void SetupMap(Tile[] tilesOnMap)
    {
        Grid = new Tile[ySize, xSize];
        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                Grid[y, x] = tilesOnMap[x + xSize * y];
                Grid[y, x].SetNeighbours(FindNeighboursForTile(Grid[y, x]));
            }
        }
    }

    private IEnumerable<Tile> FindNeighboursForTile(Tile tile)
    {
        List<Tile> neighbours = new List<Tile>();

        RaycastHit raycastHit;
        if (tile.direction.HasFlag(Tile.Direction.Right) && Physics.Raycast(tile.transform.position, Vector3.right, out raycastHit)) neighbours.Add(raycastHit.transform.GetComponent<Tile>());
        if (tile.direction.HasFlag(Tile.Direction.Left) && Physics.Raycast(tile.transform.position, Vector3.left, out raycastHit)) neighbours.Add(raycastHit.transform.GetComponent<Tile>());
        if (tile.direction.HasFlag(Tile.Direction.Forward) && Physics.Raycast(tile.transform.position, Vector3.forward, out raycastHit)) neighbours.Add(raycastHit.transform.GetComponent<Tile>());
        if (tile.direction.HasFlag(Tile.Direction.Backward) && Physics.Raycast(tile.transform.position, Vector3.back, out raycastHit)) neighbours.Add(raycastHit.transform.GetComponent<Tile>());

        return neighbours;
    }

    public IEnumerable<IWalkable> GetMapWalkables()
    {
        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                yield return Grid[y, x];
            }
        }
    }
}