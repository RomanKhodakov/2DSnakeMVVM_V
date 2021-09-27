using UnityEngine;

namespace SnakeMVVM
{
    internal sealed class PlayerInitializationViewModel
    {
        private readonly GameObject _player;

        public PlayerInitializationViewModel(IPlayerFactoryModel playerFactoryModel, IPlayerModel player)
        {
            _player = playerFactoryModel.CreatePlayer(player);
            _player.transform.position = player.Position;
        }

        public Rigidbody2D GetPlayerRigidbody() => _player.GetOrAddComponent<Rigidbody2D>();
        public Transform GetPlayerTransform() => _player.gameObject.transform;
        public int GetPlayerId() => _player.gameObject.GetInstanceID();
    }
}