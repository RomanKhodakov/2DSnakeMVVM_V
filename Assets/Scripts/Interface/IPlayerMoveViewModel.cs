namespace SnakeMVVM
{
    public interface IPlayerMoveViewModel
    {
        void Execute(float horizontal, float vertical, float deltaTime);
    }
}