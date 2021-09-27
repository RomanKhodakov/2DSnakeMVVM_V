using System.Collections.Generic;
using UnityEngine;

namespace SnakeMVVM
{
    internal sealed class BonusFactoryModel : IBonusFactoryModel
    {
        private readonly ViewServices<Bonus> _viewService;

        public BonusFactoryModel()
        {
            _viewService = new ViewServices<Bonus>();
        }

        public Bonus GetBonus()
        {
            var res = Resources.Load<Bonus>($"Bonus/Bonus");
            res.gameObject.SetName("Bonus").AddRigidbody2D(1)
                .GetOrAddComponent<CircleCollider2D>().isTrigger = true;
            return res;
        }
        
        public ViewServices<Bonus> GetBonusViewService() => _viewService;
    }
}