using System;
using UnityEngine;
using UnityEngine.UI;

namespace SnakeMVVM
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private Data _data;
        private Views _views;
        
        private void Start()
        {
            _views = new Views();
            new GameInitialization(_views, _data);
            _views.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _views.Execute(deltaTime);
        }

        private void OnDestroy()
        {
            _views.Cleanup();
        }
    }
}