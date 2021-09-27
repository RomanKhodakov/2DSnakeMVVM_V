using System.Collections.Generic;
using UnityEngine;

namespace SnakeMVVM
{
    internal sealed class BonusInitializationViewModel
    {
        public int BonusPullSize { get; private set; }
        private readonly ViewServices<Bonus> _viewService;
        private readonly IBonusFactoryModel _bonusFactory;
        private readonly Dictionary<int, Bonus> _bonusesWithId;

        public BonusInitializationViewModel(IBonusFactoryModel bonusFactory, IBonusData bonusData)
        {
            BonusPullSize = bonusData.BasePullCount;
            _viewService = bonusFactory.GetBonusViewService();
            _bonusFactory = bonusFactory;
            _bonusesWithId = new Dictionary<int, Bonus>();
        }

        public void InitializeBonusPull()
        {
            for (int i = 0; i < BonusPullSize; i++)
            {
                var instantiate = _viewService.Instantiate(_bonusFactory.GetBonus());
                _bonusesWithId.Add(instantiate.gameObject.GetInstanceID(),instantiate);
            }

            foreach (var bonus in _bonusesWithId.Values)
            {
                _viewService.Destroy(bonus);
            }
        }
        
        public void ChangeBonusPullSize(int value) => BonusPullSize += value;
        
        public Dictionary<int, Bonus> GetBonusesWithId() => _bonusesWithId;
    }
}
