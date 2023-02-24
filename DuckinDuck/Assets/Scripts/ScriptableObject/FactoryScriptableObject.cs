using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Factory", menuName = "CustomType/Factory")]
public class FactoryScriptableObject : ScriptableObject
{

    [SerializeField] public string name;
    [SerializeField] public Ressource ressource = Ressource.None;
    [SerializeField] public int productionAmount;
    [SerializeField] public float productionTimer;
    [SerializeField] public Mesh model;
    [SerializeField] public Sprite menuImage;
    
}
