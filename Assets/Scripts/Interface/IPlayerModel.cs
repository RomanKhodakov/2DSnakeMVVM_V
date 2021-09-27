using UnityEngine;

namespace SnakeMVVM
{
    public interface IPlayerModel
    {

        Sprite Sprite { get; }
        string Name { get; }
        float Speed { get; }
        float Mass { get; }
        Vector2 Position { get; }
    }
}