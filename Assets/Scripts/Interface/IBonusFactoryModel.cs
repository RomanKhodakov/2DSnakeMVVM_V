namespace SnakeMVVM
{
    internal interface IBonusFactoryModel
    {
        Bonus GetBonus();
        ViewServices<Bonus> GetBonusViewService();
    }
}