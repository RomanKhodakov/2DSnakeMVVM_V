using UnityEngine;

namespace SnakeMVVM
{
    public sealed class PlayerFactoryModel : IPlayerFactoryModel
    {
        public PlayerFactoryModel()
        {
        }

        public GameObject CreatePlayer(IPlayerModel playerModel)
        {
            return new GameObject(playerModel.Name).AddSprite(playerModel.Sprite).AddCircleCollider2D()
                .AddRigidbody2D(playerModel.Mass);
        }
    }
}