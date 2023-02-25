using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _monnaieText;
    [SerializeField] private TextMeshProUGUI _couronneText;
    [SerializeField] private TextMeshProUGUI _majordomeText;
    [SerializeField] private TextMeshProUGUI _fameText;

    public void Start()
    {
        // Debug to verify if theres not missing references
        if (_monnaieText == null || _couronneText == null || _majordomeText == null || _fameText == null)
        {
            Debug.LogError("Missing reference");
            
        }
    }

    public void UpdateUI(int _monnaie, int _couronne, int _majordome, int _fame)
    {
        _monnaieText.text = _monnaie.ToString();
        _couronneText.text = _couronne.ToString();
        _majordomeText.text = _majordome.ToString();
        _fameText.text = _fame.ToString();
    }

    public void Increase()
    {
        int n = (int) Random.Range(1, 100);

        UpdateUI(n + n, n + n * n, n * n, n + n);
    }
}