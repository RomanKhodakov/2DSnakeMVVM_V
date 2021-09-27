namespace SnakeMVVM
{
    internal interface IInputViewModel
    {
        void Execute();
        public (IUserInputProxy<float> inputHorizontal, IUserInputProxy<float> inputVertical) GetMoveInput();
    }
}