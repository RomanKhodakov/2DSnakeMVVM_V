namespace SnakeMVVM
{
    public interface IScoreModel
    {
        float CurrenScore { get; }
        public void AddScore(float value);
    }
}