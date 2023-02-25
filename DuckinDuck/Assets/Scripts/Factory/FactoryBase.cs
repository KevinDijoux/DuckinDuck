using System;
using GSGD1;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class FactoryBase : MonoBehaviour, IFactory
{
    public string factoryName { get; set; }
    public Ressource ressource { get; set; }
    public float cooldown { get; set; }
    public int quantity { get; set; }
    public Image factorySprite { get; set; }
    public int level { get; set; }
    public Timer timer { get; set; }
    
    [SerializeField] public FactoryScriptableObject assets;
    
    public void OnEnable()
    {
        factoryName = assets.name;
        ressource = assets.ressource;
        cooldown = assets.productionTimer;
        quantity = assets.productionAmount;
        factorySprite = assets.menuImage;
        level = assets.level;

        if (ressource != Ressource.None)
        {
            GameManager.Instance.AddFactory(this);
            timer = new Timer(cooldown, false);
            timer.OnEndCallback += HandleEndCallback;
            timer.Start();
        }
        else
        {
            Debug.Log("No ressource were set, aborting factory : " + this);
            gameObject.SetActive(false);
        }
        
    }

    private void Update()
    {
        timer.Update();
    }

    private void HandleEndCallback()
    {
        GameManager.Instance.IncrementRessource(ressource,  GetProductionAmount());
    }
    
    public string GetName()
    {
        return factoryName;
    }

    public Ressource GetRessource()
    {
        return ressource;
    }

    public float GetCooldown()
    {
        return cooldown;
    }

    public int GetQuantity()
    {
        return quantity;
    }

    public Image GetImage()
    {
        return factorySprite;
    }

    public int GetLevel()
    {
        return level;
    }
    
    private int GetProductionAmount()
    {
        return Mathf.CeilToInt(Mathf.Sqrt(Mathf.Pow(quantity, level)));
    }

    public string SetName(string name)
    {
        return factoryName = name;
    }

    public Ressource SetRessource(Ressource ressource)
    {
        return this.ressource = ressource;
    }

    public float SetCooldown(float cooldown)
    {
        timer.Stop();
        timer = new Timer(cooldown, false);
        timer.Start();
        return this.cooldown = cooldown;
    }

    public int SetQuantity(int quantity)
    {
        return this.quantity = quantity;
    }

    public Image SetImage(Image image)
    {
        return factorySprite = image;
    }

    public int IncrementLevel()
    {
        return level++;
    }
    

}
