using System.Collections.Generic;
using UnityEngine;

namespace SnakeMVVM
{
    internal sealed class BonusTriggerViewModel : IBonusTriggerViewModel
    {
        private readonly int _playerID;
        private readonly IScoreModel _playerScore;
        private readonly ViewServices<Bonus> _bonusViewServices;
        private readonly Dictionary<int, Bonus> _bonusesWithId;
        private readonly BonusInitializationViewModel _bonusInitialization;
        private const float Score = 200;

        public BonusTriggerViewModel(IBonusFactoryModel bonusFactory, BonusInitializationViewModel bonusInitialization, 
            PlayerInitializationViewModel player, IScoreModel playerScore)
        {
            _playerScore = playerScore;
            _bonusInitialization = bonusInitialization;
            _bonusesWithId = bonusInitialization.GetBonusesWithId();
            _playerID = player.GetPlayerId();
            _bonusViewServices = bonusFactory.GetBonusViewService();
        }
        
        public void BonusTriggerEnter(int otherID, int bonusId)
        {
            if (otherID == _playerID)
            {
                _playerScore.AddScore(Score);
                _bonusViewServices.Destroy(_bonusesWithId[bonusId]);
                _bonusInitialization.ChangeBonusPullSize(1);
            }
        }
    }
}