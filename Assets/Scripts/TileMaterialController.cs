using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileMaterialController : MonoBehaviour
{
    //public Pathfinder pathfinder;
    //public Map map;

    public Material currentMaterial;
    public Material frontierMaterial;
    public Material visitedMaterial;
    public Material startMaterial;
    public Material endMaterial;

    //private IWalkable start;
    //private IWalkable end;

    //private void Start()
    //{
    //    Map.onPathFind += OnPathFindingInitMaterials;
    //    Pathfinder.onPathUpdate += UpdateMaterials;
    //}

    //void OnPathFindingInitMaterials(IWalkable start, IWalkable end)
    //{
    //    this.start = start;
    //    this.end = end;
    //}

    //private void UpdateMaterials(Pathfinder pathfinder, IWalkable current, List<IWalkable> pathNodes)
    //{
    //    foreach (Tile tile in map.GetMapWalkables()) tile.mr.material = visitedMaterial;

    //    foreach (PathNode node in pathfinder.priorityQueue.Nodes) (node.Tile as Tile).mr.material = frontierMaterial;

    //    (current as Tile).mr.material = currentMaterial;

    //    UpdateStartAndEnd();
    //}

    //public void UpdateStartAndEnd()
    //{
    //    if (start == null || end == null) return;

    //    (start as Tile).mr.material = startMaterial;
    //    (end as Tile).mr.material = endMaterial;
    //}

    //private void OnDestroy()
    //{
    //    Map.onPathFind -= OnPathFindingInitMaterials;
    //    Pathfinder.onPathUpdate -= UpdateMaterials;
    //}
}