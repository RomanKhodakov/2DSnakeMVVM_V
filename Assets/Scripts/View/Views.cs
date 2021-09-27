using System.Collections.Generic;

namespace SnakeMVVM
{
    internal sealed class Views : IInitialization, IExecute, ICleanup
    {
        private readonly List<IInitialization> _initializeViews;
        private readonly List<IExecute> _executeViews;
        private readonly List<ICleanup> _cleanupViews;

        internal Views()
        {
            _initializeViews = new List<IInitialization>(8);
            _executeViews = new List<IExecute>(8);
            _cleanupViews = new List<ICleanup>(8);
        }

        internal Views Add(IView view)
        {
            if (view is IInitialization initializeView)
            {
                _initializeViews.Add(initializeView);
            }

            if (view is IExecute executeView)
            {
                _executeViews.Add(executeView);
            }
            
            if (view is ICleanup cleanupView)
            {
                _cleanupViews.Add(cleanupView);
            }

            return this;
        }
        
        public void Initialization()
        {
            for (var index = 0; index < _initializeViews.Count; ++index)
            {
                _initializeViews[index].Initialization();
            }
        }
        
        public void Execute(float deltaTime)
        {
            for (var index = 0; index < _executeViews.Count; ++index)
            {
                _executeViews[index].Execute(deltaTime);
            }
        }

        public void Cleanup()
        {
            for (var index = 0; index < _cleanupViews.Count; ++index)
            {
                _cleanupViews[index].Cleanup();
            }
        }
    }
}