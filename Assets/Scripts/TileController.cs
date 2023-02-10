using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {

    public Material start;
    public Material end;
    public Material locked;
    public Material empty;

    public Material frontier;
    public Material finalPath;

    //public bool IsAvailableTile(Tile tile)
    //{
    //    if (!tile.isVisited)
    //    {
    //        return tile.type == Tile.Type.Empty || tile.type == Tile.Type.Start || tile.type == Tile.Type.End;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    //public Tile.Type GetTileType (Tile tile)
    //{
    //    //Material material = tile.GetComponent<MeshRenderer>().sharedMaterial;
    //    Material material = tile.defaultColor;
    //    Tile.Type tileType = Tile.Type.Empty;

    //    tileType = material == start ? Tile.Type.Start : tileType;
    //    tileType = material == end ? Tile.Type.End : tileType;
    //    tileType = material == locked ? Tile.Type.Lock : tileType;
    //    tileType = material == empty ? Tile.Type.Empty : tileType;

    //    if(tileType == Tile.Type.Start)
    //    {
    //        GetComponent<MapController>().map.startTile = tile;
    //    }
    //    else if (tileType == Tile.Type.End)
    //    {
    //        GetComponent<MapController>().map.endTile = tile;
    //    }

    //    return tileType;
    //}

}
