using UnityEngine;

namespace SnakeMVVM
{
    internal sealed class PlayerMoveViewModel : IPlayerMoveViewModel
    {
        private readonly Rigidbody2D _playerRb;
        private Vector2 _moveDirection;
        private readonly float _playerSpeed;

        public PlayerMoveViewModel(PlayerInitializationViewModel playerInitializationViewModel, IPlayerModel playerModel)
        {
            _playerRb = playerInitializationViewModel.GetPlayerRigidbody();
            _playerSpeed = playerModel.Speed;
        }

        public void Execute(float horizontal, float vertical, float deltaTime)
        {
            _moveDirection.Set(horizontal, vertical);
            _playerRb.AddForce(_moveDirection * _playerSpeed * deltaTime);
        }
    }
}