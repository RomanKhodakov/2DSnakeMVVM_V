using System.Collections.Generic;
using UnityEngine;

namespace SnakeMVVM
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Views views, Data data)
        {
            Camera camera = Camera.main;
            var playerFactoryModel = new PlayerFactoryModel();
            var bonusFactoryModel = new BonusFactoryModel();
            var uiReferencesModel = new UIReferencesModel();
            var playerScoreModel = new ScoreModel();
            
            var playerInitializationViewModel = new PlayerInitializationViewModel(playerFactoryModel, data.Player);
            var playerMoveViewModel = new PlayerMoveViewModel(playerInitializationViewModel, data.Player);

            var bonusInitializationViewModel = new BonusInitializationViewModel(bonusFactoryModel, data.BonusData);
            var bonusSpawnerViewModel = new BonusSpawnerViewModel(data.BonusData, bonusFactoryModel, 
                bonusInitializationViewModel, playerInitializationViewModel.GetPlayerTransform());
            var bonusTriggerViewModel = new BonusTriggerViewModel(bonusFactoryModel,bonusInitializationViewModel, 
                    playerInitializationViewModel, playerScoreModel);

            var inputViewModel = new InputViewModel();
               
            var scoreViewModel = new ScoreViewModel(playerScoreModel);

            views.Add(new PlayerMoveView(inputViewModel, playerMoveViewModel));
            views.Add(new BonusSpawnerView(bonusSpawnerViewModel, bonusInitializationViewModel));
            views.Add(new BonusTriggerView(bonusInitializationViewModel, bonusTriggerViewModel));
            views.Add(new ScoreView(scoreViewModel, uiReferencesModel.PlayerScorePanel));
        }
    }
}