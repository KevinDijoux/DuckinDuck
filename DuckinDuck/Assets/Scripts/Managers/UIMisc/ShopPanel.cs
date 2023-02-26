using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{

    [SerializeField] private Sprite sprite = null;
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI quantity;
    [SerializeField] private FactoryBase _factory;
    [SerializeField] private FactoryTypeList type;

    private void OnEnable()
    {
        //name.text = _factory.GetName();
        sprite = _factory.GetImage();
        quantity.text = String.Format("{0} /s", GameManager.Instance.GetMaxProdFrom(type));

    }

    public void DestroyPanel()
    {
        Destroy(gameObject);
    }
}
