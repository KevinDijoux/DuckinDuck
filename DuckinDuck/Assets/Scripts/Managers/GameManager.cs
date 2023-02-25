using System;
using System.Collections.Generic;
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

    private List<Factory> factoryList = new List<Factory>();

    
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

    public void AddFactory(Factory factory)
    {
        factoryList.Add(factory);
    }

    public Factory GetFactoryByIndex(int index)
    {
        return factoryList[index];
    }

    public List<Factory> GetFullFactoryList()
    {
        return factoryList;
    }

    private void Start()
    {
        _uiManager.UpdateUI(Monnaie, Couronne, Majordome, Fame);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            _factoryHandler.CallMenu();
        }
    }
}

