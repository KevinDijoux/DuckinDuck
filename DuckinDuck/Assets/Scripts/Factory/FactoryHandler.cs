using System.Collections.Generic;
using UnityEngine;

public class FactoryHandler : MonoBehaviour
{

    private List<Factory> factoryList = new List<Factory>();

    public void CallMenu()
    {
        factoryList.Clear();
        List<Factory> tempFactoryList = new List<Factory>(GameManager.Instance.GetFullFactoryList());
        for (int i = 0; i < tempFactoryList.Count; i++)
        {
            factoryList.Add(tempFactoryList[i]);
        }
        Debug.Log(factoryList.Count);
    }
    
    
}
