using UnityEngine;

namespace Factory.FactoryType
{
    public class Bank : FactoryBase
    {
        [SerializeField] private bool isSupposeToWork = true;
        protected override void Start()
        {
            base.Start();
            factoryName = "Bank";
            isWorking = isSupposeToWork;
        }
    }
}