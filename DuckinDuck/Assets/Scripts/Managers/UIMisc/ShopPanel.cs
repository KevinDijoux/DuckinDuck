using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{

    [SerializeField] private Image sprite = null;
    [SerializeField] private TextMeshProUGUI amountProduced;
    [SerializeField] private FactoryScriptableObject _factory;
    private void Start()
    {
        sprite = _factory.menuImage;
        amountProduced.text = String.Format("{0} /5s", _factory.productionAmount);
    }

    public void DestroyPanel()
    {
        Destroy(gameObject);
    }
}
