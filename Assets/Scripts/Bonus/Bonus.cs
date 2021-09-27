using System;
using UnityEngine;

namespace SnakeMVVM
{
    internal class Bonus : MonoBehaviour
    {
        public event Action<int, int> OnTriggerEnterChange;

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnterChange?.Invoke(other.gameObject.GetInstanceID(), gameObject.GetInstanceID());
        }
    }
}