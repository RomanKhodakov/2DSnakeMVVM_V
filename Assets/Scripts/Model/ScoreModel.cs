namespace SnakeMVVM
{
    internal sealed class ScoreModel : IScoreModel
    {
        public float CurrenScore { get; private set; }
        
        public ScoreModel()
        {
            CurrenScore = 0;
        }

        public void AddScore(float value)
        {
            CurrenScore += value;
        }
    }
}