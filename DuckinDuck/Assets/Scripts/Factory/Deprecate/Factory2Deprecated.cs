using System;
using UnityEngine;
using GSGD1;
using Interfaces;
using UnityEngine.UI;

[System.Obsolete("This class is obsolete, create a new class that inherit from FactoryBase instead !")]
public class Factory2Deprecated : MonoBehaviour
{
    [SerializeField] private FactoryScriptableObject factorySettings;
    
    private string name = String.Empty;
    private Ressource ressourceProduced = Ressource.None;
    private float productionTime = 0;
    private int amountProduced = 5;
    private Timer _timer = null;
    private Sprite sprite = null;
    private int level = 1;

    private void OnEnable()
    {
        name = factorySettings.name;
        ressourceProduced = factorySettings.ressource;
        productionTime = factorySettings.recipeTime;
        amountProduced = factorySettings.productionAmount;
        sprite = factorySettings.menuImage;
        level = factorySettings.level;
    }

    private void Start()
    {
        if (ressourceProduced != Ressource.None)
        {
            //GameManager.Instance.AddFactory(this);
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
        GameManager.Instance.IncrementRessource(ressourceProduced,  Mathf.CeilToInt(Mathf.Sqrt(Mathf.Pow(amountProduced, level))));
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
        return Mathf.CeilToInt(Mathf.Sqrt(Mathf.Pow(amountProduced, level)));
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

    public Ressource GetRessource()
    {
        return ressourceProduced;
    }

    public int GetLevel()
    {
        return level;
    }

    public int IncrementLevel()
    {
        level++;
        return level;
    }
    #endregion
}
