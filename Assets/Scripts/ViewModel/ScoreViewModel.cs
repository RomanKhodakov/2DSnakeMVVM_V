using System;

namespace SnakeMVVM
{
    internal sealed class ScoreViewModel : IScoreViewModel
    {
        public event Action<float> OnScoreChange;
        public IScoreModel ScoreModel { get; }

        public ScoreViewModel(IScoreModel scoreModel)
        {
            ScoreModel = scoreModel;
        }

        public void ApplyScore()
        {
            OnScoreChange?.Invoke(ScoreModel.CurrenScore);
        }
    }
}