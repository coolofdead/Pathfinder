using System.Collections;
using System.Collections.Generic;

public interface IPathFindable
{
    IEnumerable<IWalkable> GetMapWalkables();
}
