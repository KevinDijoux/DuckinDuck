using UnityEngine;

namespace Factory.FactoryType
{
    public class Hostel : FactoryBase
    {
        [SerializeField] private bool isSupposeToWork = true;
        protected override void Start()
        {
            base.Start();
            factoryName = "Hostel";
            isWorking = isSupposeToWork;
        }
    }
}