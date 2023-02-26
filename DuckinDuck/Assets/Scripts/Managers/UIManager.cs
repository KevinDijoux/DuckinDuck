using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _monnaieText;
    [SerializeField] private TextMeshProUGUI _couronneText;
    [SerializeField] private TextMeshProUGUI _majordomeText;
    [SerializeField] private TextMeshProUGUI _fameText;

    [SerializeField] private GameObject _selectInterface;
    [SerializeField] private GameObject _overviewInterface;
    [SerializeField] private GameObject _upgradeInterface;

    private FactoryBase _factory;
    public FactoryBase Factory => _factory;

    private GameObject _location;
    public GameObject Location => _location;

    private Transform _anchor;
    public Transform Anchor => _anchor;

    public void Start()
    {
        _selectInterface.SetActive(false);
        _overviewInterface.SetActive(false);

        // Debug to verify if theres not missing references
        if (_monnaieText == null || _couronneText == null || _majordomeText == null || _fameText == null)
        {
            Debug.LogWarning("Missing reference");
        }
    }

    public void UpdateUI(int _monnaie, int _couronne, int _majordome, int _fame)
    {
        _monnaieText.text = _monnaie.ToString();
        _couronneText.text = _couronne.ToString();
        _majordomeText.text = _majordome.ToString();
        _fameText.text = _fame.ToString();
    }

    public void OpenSelectionHUD()
    {
        _selectInterface.SetActive(true);
    }

    public void CloseSelectionHUD()
    {
        _selectInterface.SetActive(false);
    }

    public void OpenOverviewHUD()
    {
        _overviewInterface.SetActive(true);
    }

    public void CloseOverviewHUD()
    {
        _overviewInterface.SetActive(false);
    }

    public void OpenUpgradeHUD()
    {
        _upgradeInterface.GetComponent<Animator>().SetBool("Entry", true);
    }

    public void CloseUpgradeHUD()
    {
        _upgradeInterface.GetComponent<Animator>().SetBool("Entry", false);
    }

    public void SetLocation(GameObject location)
    {
        _location = location;
    }

    public void SetAnchor(Transform anchor)
    {
        _anchor = anchor;
    }

    public void ChooseFactory(FactoryBase factory)
    {
        _factory = factory;
        CreateFactory();
    }

    public void CreateFactory()
    {
        Instantiate(_factory, _anchor);
        DeleteLocation();
    }

    public void DeleteLocation()
    {
        Debug.Log(_location.name);
        CloseSelectionHUD();
        _location.GetComponent<MeshRenderer>().enabled = false;
        _location.GetComponent<MeshCollider>().enabled = false;
    }
}