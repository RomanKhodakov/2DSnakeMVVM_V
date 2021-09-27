using UnityEngine;

namespace SnakeMVVM
{
    [CreateAssetMenu(fileName = "UnitSettings", menuName = "Data/Unit/UnitSettings")]
    public sealed class PlayerData : ScriptableObject, IPlayerModel
    {
        public Sprite playerSprite;
        [SerializeField] private string _name;
        [SerializeField, Range(0.01f, 3000)] private float _speed;
        [SerializeField, Range(0.01f, 10)] private float _mass;
        [SerializeField] private Vector2Int _position;
        public Sprite Sprite => playerSprite;
        public string Name => _name;
        public float Speed => _speed;
        public float Mass => _mass;
        public Vector2 Position => _position;
    }
}