using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    
    [SerializeField] private Image sprite = null;
    [SerializeField] private TextMeshProUGUI factoryName;
    [SerializeField] private TextMeshProUGUI ressource;
    [SerializeField] private TextMeshProUGUI amountProduced;
    
    public void WhenEnabled(Image spriteToSet, String factoryNameToSet, String ressourceToSet, int amountToSet)
    {
        sprite = spriteToSet;
        factoryName.text = factoryNameToSet;
        ressource.text = ressourceToSet;
        amountProduced.text = amountToSet.ToString();
    }

    public void DestroyPanel()
    {
        Destroy(gameObject);
    }
}
