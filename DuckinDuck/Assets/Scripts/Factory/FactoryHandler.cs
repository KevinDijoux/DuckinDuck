using System;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class FactoryHandler : MonoBehaviour
{
    [SerializeField] private Factory2Deprecated auberge;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            auberge.GetProductionAmount();
        }
    }


    /*
    [SerializeField] private GameObject contentBox;
    [SerializeField] private ShopPanel panelPrefab;
    [SerializeField] private List<ShopPanel> panelList;
    [SerializeField] private List<Factory> factoryList;
    
    

    public void CallMenu()
    {
        
        CleanMenu();
        for (int i = 0; i < panelList.Count; i++)
        {
            panelList[i].WhenEnabled(
                factoryList[i].GetSprite(), 
                tempFactory.GetName(), 
                tempFactory.GetRessource().ToString(), 
                tempFactory.GetProductionAmount(),
                tempFactory.GetLevel());
            panelList.Add(panel);
        }
        
    }

    private void CleanMenu()
    {
        if (panelList.Count > 0)
        {
            for (int i = 0; i < panelList.Count; i++)
            {
                panelList[i].DestroyPanel();
            }
            panelList.Clear();
        }
    }
    */
}
