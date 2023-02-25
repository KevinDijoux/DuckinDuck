using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{

    [SerializeField] private Image sprite = null;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI quantity;
    [SerializeField] private TextMeshProUGUI ressource;
    [SerializeField] private FactoryBase _factory;
    private void OnEnable()
    {
        name.text = _factory.GetName();
        sprite = _factory.GetImage();
        ressource.text = _factory.GetRessource().ToString();
        quantity.text = String.Format("{0} /s", _factory.GetQuantity().ToString());
    }

    public void DestroyPanel()
    {
        Destroy(gameObject);
    }
}
