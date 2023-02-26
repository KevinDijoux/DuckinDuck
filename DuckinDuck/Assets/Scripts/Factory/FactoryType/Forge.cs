using System;
using UnityEngine;

namespace Factory.FactoryType
{
    public class Forge : FactoryBase
    {
        [SerializeField] private bool isSupposeToWork = true;
        protected override void Start()
        {
            base.Start();
            factoryName = "Forge";
            isWorking = isSupposeToWork;
        }
    }
}