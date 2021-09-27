using UnityEngine;

namespace SnakeMVVM
{
    public sealed class InputViewModel : IInputViewModel
    {
        private readonly IUserInputProxy<float> _inputHorizontal;
        private readonly IUserInputProxy<float> _inputVertical;

        public InputViewModel()
        {
            _inputHorizontal = new PCInputHorizontal();
            _inputVertical = new PCInputVertical();
        }

        public void Execute()
        {
            _inputHorizontal.GetAxis();
            _inputVertical.GetAxis();
        }
        public (IUserInputProxy<float> inputHorizontal, IUserInputProxy<float> inputVertical) GetMoveInput()
        {
            (IUserInputProxy<float> inputHorizontal, IUserInputProxy<float> inputVertical) result =
                    (_inputHorizontal, _inputVertical);
            return result;
        }
    }
}