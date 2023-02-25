using GSGD1;
using UnityEngine;

[System.Obsolete("This class is obsolete, create a new class that inherit from FactoryBase instead !")]
public class FactoryDeprecated : MonoBehaviour
{
    [SerializeField] private Ressource ressourceAimed = Ressource.None;
    [SerializeField] private float productionTime = 0f;
    [SerializeField] private int amountProduced = 0;
    private Ressource _ressourceProduced = Ressource.None;
    private Timer _timer;
    
    private void Start()
    {
        if (ressourceAimed != Ressource.None)
        {
            _timer = new Timer(productionTime, false);
            _timer.OnEndCallback += HandleEndCallback;
            _ressourceProduced = ressourceAimed;
            _timer.Start();
        }

        else
        {
            Debug.Log("No ressource were set, aborting factory : " + this);
            gameObject.SetActive(false);
        }

    }

    private void Update()
    {
        _timer.Update();
    }

    private void HandleEndCallback()
    {
        GameManager.Instance.IncrementRessource(_ressourceProduced, amountProduced);
    }

    public void UpdateProductionTime(float duration)
    {
        _timer.Stop();
        _timer = new Timer(duration, false);
        _timer.Start();
    }

    
    public float GetProductionTime()
    {
        return _timer.Duration;
    }
}
