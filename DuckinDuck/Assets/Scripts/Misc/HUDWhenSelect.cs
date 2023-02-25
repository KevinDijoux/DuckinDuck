using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.ProBuilder.AutoUnwrapSettings;

public class HUDWhenSelect : MonoBehaviour
{
    private Transform _anchor;
    public Transform Anchor => _anchor;

    public void OnSelect()
    {
        Debug.Log("Select");

        GameManager.Instance.UIManager.OpenHUD();
    }

    public void OnDeselect()
    {
        //Debug.Log("Deselect");

        GameManager.Instance.UIManager.CloseHUD();
    }
}
