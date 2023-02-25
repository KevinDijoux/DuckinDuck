using System;
using System.Collections.Generic;
using Interfaces;
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

    private int Monnaie = 0;
    private int Couronne = 0;
    private int Majordome = 0;
    private int Fame = 0;

    private List<FactoryBase> factoryList = new List<FactoryBase>();

    
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

    public void UpdateUI()
    {
        _uiManager.UpdateUI(Monnaie, Couronne, Majordome, Fame);
    }

    public void AddFactory(FactoryBase factory)
    {
        factoryList.Add(factory);
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
        _uiManager.UpdateUI(Monnaie, Couronne, Majordome, Fame);
        /*
        for (int i = 1; i < 11; i++)
        {
            Debug.Log(Mathf.CeilToInt(Mathf.Sqrt(Mathf.Pow(5, i))));
        }
        */
    }
    
    

}

