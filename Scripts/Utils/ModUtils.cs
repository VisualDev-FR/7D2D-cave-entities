using System.Diagnostics;
using System.IO;
using System.Linq;
using UnityEngine;

public class ModUtils
{
    public static readonly Vector3i[] offsets = new Vector3i[]
    {
        new Vector3i(1, 0, 0),
        new Vector3i(-1, 0, 0),
        new Vector3i(0, 1, 0),
        new Vector3i(0, -1, 0),
        new Vector3i(0, 0, 1),
        new Vector3i(0, 0, -1),
        new Vector3i(0, 1, 1),
        new Vector3i(0, -1, 1),
        new Vector3i(0, 1, -1),
        new Vector3i(0, -1, -1),
        new Vector3i(1, 0, 1),
        new Vector3i(-1, 0, 1),
        new Vector3i(1, 0, -1),
        new Vector3i(-1, 0, -1),
        new Vector3i(1, 1, 0),
        new Vector3i(1, -1, 0),
        new Vector3i(-1, 1, 0),
        new Vector3i(-1, -1, 0),
        new Vector3i(1, 1, 1),
        new Vector3i(1, -1, 1),
        new Vector3i(1, 1, -1),
        new Vector3i(1, -1, -1),
        new Vector3i(-1, 1, 1),
        new Vector3i(-1, -1, 1),
        new Vector3i(-1, 1, -1),
        new Vector3i(-1, -1, -1)
    };

    public static readonly Vector3i[] offsetsNoVertical = offsets
        .Where(offset => offset.y == 0 || offset.x != 0 || offset.z != 0)
        .ToArray();

    public static float SqrEuclidianDist(Vector3 p1, Vector3 p2)
    {
        float dx = p1.x - p2.x;
        float dy = p1.y - p2.y;
        float dz = p1.z - p2.z;

        return dx * dx + dy * dy + dz * dz;
    }

    public static Stopwatch StartTimer()
    {
        var timer = new Stopwatch();
        timer.Start();
        return timer;
    }

    public static BlockValue GetBlockValue(string blockName)
    {
        if (Block.nameToBlock.TryGetValue(blockName, out var block))
        {
            return block.ToBlockValue();
        }

        throw new InvalidDataException($"block '{blockName}' does not exist. (case maybe invalid)");
    }

    public static bool IsTerrain(BlockValue blockValue)
    {
        return blockValue.Block.shape.IsTerrain();
    }

}