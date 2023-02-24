using UnityEngine;

namespace GameMode
{
    public class GameManager : MonoBehaviour
    {
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
    }
}