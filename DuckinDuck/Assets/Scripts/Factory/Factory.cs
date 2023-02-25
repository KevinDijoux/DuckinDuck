using System;
using UnityEngine;
using GSGD1;

public class Factory : MonoBehaviour
{
    [SerializeField] private FactoryScriptableObject factorySettings;
    
    private string name = String.Empty;
    private Ressource ressourceProduced = Ressource.None;
    private float productionTime = 0;
    private int amountProduced = 0;
    private Timer _timer = null;
    private Sprite sprite = null;

    private void OnEnable()
    {
        name = factorySettings.name;
        ressourceProduced = factorySettings.ressource;
        productionTime = factorySettings.productionTimer;
        amountProduced = factorySettings.productionAmount;
        sprite = factorySettings.menuImage;
    }

    private void Start()
    {
        if (ressourceProduced != Ressource.None)
        {
            GameManager.Instance.AddFactory(this);
            _timer = new Timer(productionTime, false);
            _timer.OnEndCallback += HandleEndCallback;
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
        GameManager.Instance.IncrementRessource(ressourceProduced, amountProduced);
    }

    #region RandomBullshitMethod
    public void SetProductionTime(float duration)
    {
        _timer.Stop();
        _timer = new Timer(duration, false);
        _timer.Start();
    }
    
    public float GetProductionTime()
    {
        return _timer.Duration;
    }

    public int GetProductionAmount()
    {
        return amountProduced;
    }

    public void SetProductionAmount(int amount)
    {
        amountProduced = amount;
    }
    
    public string GetName()
    {
        return name;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }
    #endregion
}
