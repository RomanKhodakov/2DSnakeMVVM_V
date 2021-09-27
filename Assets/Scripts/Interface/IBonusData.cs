using UnityEngine;

namespace SnakeMVVM
{
    public interface IBonusData
    {
        int BasePullCount { get; }
        float SpawnRange { get; }
        float SpawnTime { get; }
    }
}