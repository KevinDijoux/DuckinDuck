using UnityEngine;

public enum Ressource
{
    Monnaie,
    Couronne,
    Majordome,
    Fame,
    None
}

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;

    public UIManager UIManager => _uiManager;

    public static GameManager _instance = null;
    public static bool HasInstance => _instance != null;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var instances = FindObjectsOfType<GameManager>();
                if (instances == null || instances.Length == 0)
                {
                    Debug.LogError("No instance of GameManager found");
                    return null;
                }
                else if (instances.Length > 1)
                {
                    Debug.LogError("Multiples instances of GameManager found, there MUST be only one.");
                    return null;
                }
                _instance = instances[0];
            }
            return _instance;
        }
    }

    private int Monnaie = 0;
    private int Couronne = 0;
    private int Majordome = 0;
    private int Fame = 0;

    
    public void IncrementRessource(Ressource resource, int amount)
    {
        switch (resource)
        {
            case Ressource.Monnaie:
                Monnaie += amount;
                break;
                
            case Ressource.Couronne:
                Couronne += amount;
                break;
                
            case Ressource.Majordome:
                Majordome += amount;
                break;
                
            case Ressource.Fame:
                Fame += amount;
                break;
        }

        UpdateUI(resource);

    }

    public int UpdateUI(Ressource ressource)
    {
        switch (ressource)
        {
            case Ressource.Monnaie:
                return Monnaie;
                
            case Ressource.Couronne:
                return Couronne;
                
            case Ressource.Majordome:
                return Majordome;
                
            case Ressource.Fame:
                return Fame;
        }

        return 0;
    }


    /// <summary>
    /// Basically debug purpose
    /// </summary>
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            print("Monnaie : " + Monnaie.ToString());
            print("Couronne : " + Couronne.ToString());
            print("Majordome : " + Majordome.ToString());
            print("Fame : " + Fame.ToString());
        }
    }
}

