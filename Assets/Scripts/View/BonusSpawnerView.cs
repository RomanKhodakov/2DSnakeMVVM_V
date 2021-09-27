namespace SnakeMVVM
{
    internal sealed class BonusSpawnerView : IInitialization, IExecute
    {
        private readonly IBonusSpawnerViewModel _bonusSpawner;
        private readonly BonusInitializationViewModel _bonusInitialization;

        public BonusSpawnerView(IBonusSpawnerViewModel bonusSpawner, BonusInitializationViewModel bonusInitialization)
        {
            _bonusSpawner = bonusSpawner;
            _bonusInitialization = bonusInitialization;
        }

        public void Initialization()
        {
            _bonusInitialization.InitializeBonusPull();
        }
        
        public void Execute(float deltaTime)
        {
            if (_bonusInitialization.BonusPullSize > 0)
            {
                _bonusSpawner.SpawnBonus(deltaTime);
            }
        }
    }
}