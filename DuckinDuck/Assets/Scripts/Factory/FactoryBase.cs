using System;
using GSGD1;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

public enum FactoryTypeList
{
    Bank,
    Forge,
    Hostel,
    None
}


public class FactoryBase : MonoBehaviour, IFactory
{
    public string factoryName { get; set; }
    public Ressource ressource { get; set; }
    public float cooldown { get; set; }
    public int quantity { get; set; }
    public Sprite factorySprite { get; set; }
    public int level { get; set; }
    public Timer timer { get; set; }
    public FactoryTypeList type { get; set; }

    protected bool isWorking = true;

    [SerializeField] public FactoryScriptableObject assets;
    [SerializeField] public DuckSpawner Spawner;
    
    protected virtual void Start()
    {
        factoryName = assets.name;
        ressource = assets.ressource;
        cooldown = assets.recipeTime;
        quantity = assets.productionAmount;
        factorySprite = assets.menuImage;
        level = assets.level;
        type = assets.type;

        if (isWorking)
        {
            if (ressource != Ressource.None && type != FactoryTypeList.None)
            {
                GameManager.Instance.AddFactory(this);
                GameManager.Instance.AddToSpecificFactoryList(type, this);
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
    }

    public void TryUpgrading()
    {
        int price = Mathf.CeilToInt(Mathf.Pow(quantity, 2));
        int stock = GameManager.Instance.GetRessource(ressource);
        if (stock >= price)
        {
            IncrementLevel();
        }
        else
        {
            throw new Exception(String.Format(
                "You don't have enough {0}, your stock is {1} and price is {2}",
                ressource.ToString(),
                stock,
                price));
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

    public FactoryTypeList GetFactoryType()
    {
        return type;
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

    public Sprite GetImage()
    {
        return factorySprite;
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetProductionAmount()
    {
        return Mathf.CeilToInt(Mathf.Sqrt(Mathf.Pow(quantity, level)));
    }

    public FactoryScriptableObject GetAssets()
    {
        return assets;
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

    public Sprite SetImage(Sprite image)
    {
        return factorySprite = image;
    }

    public int IncrementLevel()
    {
        return level++;
    }
}
