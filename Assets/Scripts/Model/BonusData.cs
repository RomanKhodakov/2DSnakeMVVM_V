using UnityEngine;

namespace SnakeMVVM
{
    [CreateAssetMenu(fileName = "BonusSettings", menuName = "Data/Bonus/BonusSettings")]
    public sealed class BonusData : ScriptableObject, IBonusData
    {
        [SerializeField, Range(1, 30)] private int _basePullCount;
        [SerializeField, Range(10, 100)] private float _spawnRange;
        [SerializeField, Range(0.5f, 10)] private float _spawnTime;
        public int BasePullCount => _basePullCount;
        public float SpawnRange => _spawnRange;
        public float SpawnTime => _spawnTime;
    }
}