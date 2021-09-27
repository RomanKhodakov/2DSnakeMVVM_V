using UnityEngine;

namespace SnakeMVVM
{
    internal sealed class PlayerMoveView : IExecute, ICleanup
    {
        private float _horizontal;
        private float _vertical;
        private readonly IUserInputProxy <float>  _horizontalInputProxy;
        private readonly IUserInputProxy <float>  _verticalInputProxy;
        private readonly IInputViewModel _inputViewModel;
        private readonly IPlayerMoveViewModel _playerMoveViewModel;

        public PlayerMoveView(IInputViewModel inputViewModel, IPlayerMoveViewModel playerMoveViewModel)
        {
            _inputViewModel = inputViewModel;
            _playerMoveViewModel = playerMoveViewModel;
            _horizontalInputProxy = _inputViewModel.GetMoveInput().inputHorizontal;
            _verticalInputProxy = _inputViewModel.GetMoveInput().inputVertical;
            _horizontalInputProxy.AxisOnChange += HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange += VerticalOnAxisOnChange;
        }

        private void HorizontalOnAxisOnChange(float value)
        {
            _horizontal = value;
        }

        private void VerticalOnAxisOnChange(float value)
        {
            _vertical = value;
        }

        public void Execute(float deltaTime)
        {
            _inputViewModel.Execute();
            _playerMoveViewModel.Execute(_horizontal, _vertical, deltaTime);
        }

        public void Cleanup()
        {
            _horizontalInputProxy.AxisOnChange -= HorizontalOnAxisOnChange;
            _verticalInputProxy.AxisOnChange -= VerticalOnAxisOnChange;
        }
    }
}