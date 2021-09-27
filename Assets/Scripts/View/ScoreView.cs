using UnityEngine;
using UnityEngine.UI;

namespace SnakeMVVM
{
    internal sealed class ScoreView : IInitialization, IExecute, ICleanup
    {
        private readonly Text _text;
        private readonly IScoreViewModel _scoreViewModel;

        public ScoreView (IScoreViewModel scoreViewModel, GameObject playerScorePanel)
        {
            _text = playerScorePanel.GetComponentInChildren<Text>();;
            _scoreViewModel = scoreViewModel;
        }
        
        public void Initialization()
        {
            _scoreViewModel.OnScoreChange += OnScoreChange;
            OnScoreChange(_scoreViewModel.ScoreModel.CurrenScore);
        }
        
        private void OnScoreChange(float currentScore)
        {
            _text.text = currentScore.ToString();
        }
        
        public void Execute(float deltaTime)
        {
            _scoreViewModel.ApplyScore();
        }


        public void Cleanup()
        {
            _scoreViewModel.OnScoreChange -= OnScoreChange;
        }
    }
}