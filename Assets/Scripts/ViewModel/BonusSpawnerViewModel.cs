using System.Collections.Generic;
using UnityEngine;

namespace SnakeMVVM
{
    internal sealed class BonusSpawnerViewModel : IBonusSpawnerViewModel
    {
        private readonly float _spawnTime;
        private readonly float _spawnRange;
        private float _currentTimeSpawn;
        private readonly ViewServices<Bonus> _viewService;
        private float _randomAngle;
        private Vector3 _spawnDistance;
        private readonly Transform _playerTransform;
        private readonly IBonusFactoryModel _bonusFactory;
        private readonly BonusInitializationViewModel _bonusInitialization;

        public BonusSpawnerViewModel(IBonusData bonusData, IBonusFactoryModel bonusFactory, 
            BonusInitializationViewModel bonusInitialization, Transform playerTransform)
        {
            _spawnTime = bonusData.SpawnTime;
            _spawnRange = bonusData.SpawnRange;
            _viewService = bonusFactory.GetBonusViewService();
            _bonusInitialization = bonusInitialization;
            _bonusFactory = bonusFactory;
            _playerTransform = playerTransform;
        }
        private void CreateNewBonus(Transform playerTransform)
        {
            _randomAngle = Random.Range(-Mathf.PI, Mathf.PI);
            _spawnDistance.Set(_spawnRange * Mathf.Cos(_randomAngle),
                _spawnRange * Mathf.Sin(_randomAngle), 0);
            var instance = _viewService.Instantiate(_bonusFactory.GetBonus());
            instance.transform.position = playerTransform.position + _spawnDistance;
            _bonusInitialization.ChangeBonusPullSize(-1);
        }

        public void SpawnBonus(float deltaTime)
        {
            if (_bonusInitialization.BonusPullSize > 0)
            {
                _currentTimeSpawn += deltaTime;
                if (_currentTimeSpawn > _spawnTime)
                {
                    CreateNewBonus(_playerTransform);
                    _currentTimeSpawn -= _spawnTime;
                }
            }
        }
    }
}