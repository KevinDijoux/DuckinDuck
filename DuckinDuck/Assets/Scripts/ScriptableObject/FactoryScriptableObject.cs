using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Factory", menuName = "CustomType/Factory")]
public class FactoryScriptableObject : ScriptableObject
{

    [SerializeField] public string name;
    [SerializeField] public Ressource ressource = Ressource.None;
    [SerializeField] public int productionAmount;
    [SerializeField] public float productionTimer = 5f;
    [SerializeField] public Factory _prefab;
    [SerializeField] public Image menuImage;
    
}
