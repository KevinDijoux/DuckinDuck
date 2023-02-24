using GSGD1;
using UnityEngine;

public class Factory : MonoBehaviour
{
    [SerializeField] private Ressource ressourceAimed = Ressource.None;
    [SerializeField] private float productionTime = 0f;
    [SerializeField] private int amountProduced = 0;
    private Ressource _ressourceProduced = Ressource.None;
    private Timer _timer = null;
    
    private void Start()
    {
        if (ressourceAimed != Ressource.None)
        {
            _timer = new Timer(productionTime, false);
            _timer.OnEndCallback += HandleEndCallback;
            _ressourceProduced = ressourceAimed;
            _timer.Start();
        }

        else
        {
            Debug.Log("No ressource were set, aborting factory : " + this);
            gameObject.SetActive(false);
        }

    }

    private void Update()
    {
        _timer.Update();
    }

    private void HandleEndCallback()
    {
        GameManager.Instance.IncrementRessource(_ressourceProduced, amountProduced);
    }
}
