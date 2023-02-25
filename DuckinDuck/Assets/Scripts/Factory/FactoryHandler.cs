using System.Collections.Generic;
using UnityEngine;

public class FactoryHandler : MonoBehaviour
{

    [SerializeField] private GameObject contentBox;
    [SerializeField] private ShopPanel panelPrefab;
    
    private List<Factory> factoryList = new List<Factory>();

    public void CallMenu()
    {
        factoryList.Clear();
        factoryList = new List<Factory>(GameManager.Instance.GetFullFactoryList());
        for (int i = 0; i < factoryList.Count; i++)
        {
            Factory tempFactory = factoryList[i];
            ShopPanel panel = Instantiate(panelPrefab, contentBox.transform);
            panel.WhenEnabled(
                tempFactory.GetSprite(), 
                tempFactory.GetName(), 
                tempFactory.GetRessource().ToString(), 
                tempFactory.GetProductionAmount());
        }
        Debug.Log(factoryList.Count);
    }

}
