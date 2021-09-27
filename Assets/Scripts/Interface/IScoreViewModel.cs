using System;

namespace SnakeMVVM
{
    public interface IScoreViewModel
    {
        IScoreModel ScoreModel { get; }
        void ApplyScore();
        event Action<float> OnScoreChange;
    }
}