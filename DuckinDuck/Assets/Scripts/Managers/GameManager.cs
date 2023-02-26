using Factory.FactoryType;
using Interfaces;
using System;
using System.Collections.Generic;
using GSGD1;
using UnityEngine;

public enum Ressource
{
    Monnaie,
    Couronne,
    Majordome,
    Fame,
    None
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private FactoryHandler _factoryHandler;
    private Timer fameTimer;


    public UIManager UIManager => _uiManager;

    public static GameManager _instance = null;
    public static bool HasInstance => _instance != null;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var instances = FindObjectsOfType<GameManager>();
                if (instances == null || instances.Length == 0)
                {
                    Debug.LogError("No instance of GameManager found");
                    return null;
                }
                else if (instances.Length > 1)
                {
                    Debug.LogError("Multiples instances of GameManager found, there MUST be only one.");
                    return null;
                }
                _instance = instances[0];
            }
            return _instance;
        }
    }

    private int Monnaie = 250;
    private int Couronne = 250;
    private int Majordome = 250;
    private int Fame = 0;

    private List<FactoryBase> factoryList = new List<FactoryBase>();
    private List<Forge> forgeList = new List<Forge>();
    private List<Hostel> hostelList = new List<Hostel>();
    private List<Bank> bankList = new List<Bank>();


    public void IncrementRessource(Ressource resource, int amount)
    {
        switch (resource)
        {
            case Ressource.Monnaie:
                Monnaie += amount;
                break;
                
            case Ressource.Couronne:
                Couronne += amount;
                break;
                
            case Ressource.Majordome:
                Majordome += amount;
                break;
                
            case Ressource.Fame:
                Fame += amount;
                break;
        }

        UpdateUI();
    }
    
    public int GetRessource(Ressource resource)
    {
        switch (resource)
        {
            case Ressource.Monnaie:
                return Monnaie;

            case Ressource.Couronne:
                return Couronne;
                
            case Ressource.Majordome:
                return Majordome;

            case Ressource.Fame:
                return Fame;
        }

        throw new Exception("No valid ressource were given !");
    }

    public void UpdateUI()
    {
        _uiManager.UpdateUI(Monnaie, Couronne, Majordome, Fame);
    }

    public void AddFactory(FactoryBase factory)
    {
        factoryList.Add(factory);
    }

    public void AddToSpecificFactoryList(FactoryTypeList type, FactoryBase factory)
    {
        switch(type)
        {
            case FactoryTypeList.Bank:
                bankList.Add((Bank) factory);
                break;

            case FactoryTypeList.Hostel:
                hostelList.Add((Hostel)factory);
                break;

            case FactoryTypeList.Forge:
                forgeList.Add((Forge) factory);
                break;
        }
    }

    public long GetMaxProdFrom(FactoryTypeList type)
    {
        long result = 0;
        switch (type)
        {
            case FactoryTypeList.Bank:
                if (bankList.Count > 0)
                {
                    for (int i = 0; i < bankList.Count; i++)
                    {
                        result += bankList[i].GetProductionAmount();
                    }
                    return result;
                }
                break;

            case FactoryTypeList.Hostel:
                if (hostelList.Count > 0)
                {
                    for (int i = 0; i < hostelList.Count; i++)
                    {
                        result += hostelList[i].GetProductionAmount();
                    }
                    return result;
                }
                break;

            case FactoryTypeList.Forge:
                if (forgeList.Count > 0)
                {
                    for (int i = 0; i < forgeList.Count; i++)
                    {
                        result += forgeList[i].GetProductionAmount();
                    }
                    return result;
                }
                break;
        }
        return result;
    }

    public FactoryBase GetFactoryByIndex(int index)
    {
        return factoryList[index];
    }

    public List<FactoryBase> GetFullFactoryList()
    {
        return factoryList;
    }

    private void Start()
    {
        UpdateUI();
        fameTimer = new Timer(3, false);
        fameTimer.OnEndCallback += HandleEndCallback;
        fameTimer.Start();
    }

    private void HandleEndCallback()
    {
        Fame = Mathf.CeilToInt(((Couronne*2)+(Monnaie)+(Majordome*3))/100);
        UpdateUI();
    }

    private void Update()
    {
        fameTimer.Update();
    }

    public bool CanAfford(FactoryTypeList type)
    {
        switch (type)
        {
            case FactoryTypeList.Bank:
                if (Monnaie >= 200)
                {
                    Monnaie -= 200;
                    return true;
                }

                return false;

            case FactoryTypeList.Hostel:
                if (Majordome >= 200)
                {
                    Majordome -= 200;
                    return true;
                }

                return false;

            case FactoryTypeList.Forge:
                if (Couronne >= 200)
                {
                    Couronne -= 200;
                    return true;
                }

                return false;
        }

        return false;
    }
}

