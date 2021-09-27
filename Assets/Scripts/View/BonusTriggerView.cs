using System.Collections.Generic;

namespace SnakeMVVM
{
    internal sealed class BonusTriggerView : IInitialization, ICleanup
    {
        private readonly Dictionary<int, Bonus> _bonusesWithId;
        private readonly IBonusTriggerViewModel _bonusTrigger;

        public BonusTriggerView(BonusInitializationViewModel bonusInitialization, IBonusTriggerViewModel bonusTrigger)
        {
            _bonusTrigger = bonusTrigger;
            _bonusesWithId = bonusInitialization.GetBonusesWithId();
        }

        public void Initialization()
        {
            foreach (var bonus in _bonusesWithId.Values)
            {
                bonus.OnTriggerEnterChange += BonusOnOnTriggerEnterChange;
            }
        }
        
        private void BonusOnOnTriggerEnterChange(int otherID, int bonusId)
        {
            _bonusTrigger.BonusTriggerEnter(otherID, bonusId);
        }

        public void Cleanup()
        {
            foreach (var bonus in _bonusesWithId.Values)
            {
                bonus.OnTriggerEnterChange -= BonusOnOnTriggerEnterChange;
            }
        }
    }
}