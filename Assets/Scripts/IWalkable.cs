using System.Collections.Generic;

public interface IWalkable
{
    IEnumerable<IWalkable> GetNeighbours();
}
