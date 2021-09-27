using System;

namespace SnakeMVVM
{
    public interface IUserInputProxy <T>
    {
        event Action<T> AxisOnChange;
        void GetAxis();
    }
}