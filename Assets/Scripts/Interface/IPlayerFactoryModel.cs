using UnityEngine;

namespace SnakeMVVM
{
    public interface IPlayerFactoryModel
    {
        GameObject CreatePlayer(IPlayerModel playerModel);
    }
}