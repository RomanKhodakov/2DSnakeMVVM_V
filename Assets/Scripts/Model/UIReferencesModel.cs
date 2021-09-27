using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakeMVVM
{
    internal sealed class UIReferencesModel
    {
        private Canvas _canvas;
        private GameObject _playerScorePanel;
        
        private Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }
        }
        public GameObject PlayerScorePanel
        {
            get
            {
                if (_playerScorePanel == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/PlayerScorePanel");
                    _playerScorePanel = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _playerScorePanel;
            }
        }
    }
}