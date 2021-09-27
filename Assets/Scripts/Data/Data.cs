using System.IO;
using UnityEngine;


namespace SnakeMVVM
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    internal sealed class Data : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _bonusDataPath;
        private PlayerData _player;
        private BonusData _bonusData;
        
        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>("Data/" + _playerDataPath);
                }

                return _player;
            }
        }
        public BonusData BonusData
        {
            get
            {
                if (_bonusData == null)
                {
                    _bonusData = Load<BonusData>("Data/" + _bonusDataPath);
                }

                return _bonusData;
            }
        }
        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    }
}