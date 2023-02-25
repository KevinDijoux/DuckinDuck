using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Factory", menuName = "CustomType/Factory")]
public class FactoryScriptableObject : ScriptableObject
{

    [SerializeField] public string name;
    [SerializeField] public Ressource ressource = Ressource.None;
    [SerializeField] public int productionAmount = 5;
    [SerializeField] public float productionTimer = 5f;
    [SerializeField] public Factory2Deprecated _prefab;
    [SerializeField] public int level = 1;
    [SerializeField] public Image menuImage;
    
}
