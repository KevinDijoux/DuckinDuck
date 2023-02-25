using UnityEngine;
using UnityEngine.EventSystems;

//Made by Melinon Remy
public class Selector : MonoBehaviour
{
    public GameObject towerHUD;
    public GameObject usineHUD;
    [SerializeField] LayerMask interactibleLayer;
    //private HUDwhenSelect openHUDref;
    private bool isMouseOnUI;
    [SerializeField] private Transform anchor = null;
    //[SerializeField] private HUDAnimationController hudAnimationController;
    public bool IsMouseOnUI => isMouseOnUI;

    public void Select()
    {
        RaycastToOpenHUDRef();
    }

    private void RaycastToOpenHUDRef()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.MaxValue, interactibleLayer) && !isMouseOnUI)
        {
            if (openHUDref != null)
            {
                openHUDref.OnDeselect();
                //openHUDref.DisconnectToEvents();
                openHUDref = null;
            }
            if (hit.transform.gameObject.GetComponent<HUDwhenSelect>() != null)
            {
                openHUDref = hit.transform.gameObject.GetComponent<HUDwhenSelect>();
                openHUDref.SetAnchor(anchor);
                openHUDref.OnSelect();
            }
        }
        else if (openHUDref != null && !isMouseOnUI)
        {
            openHUDref.OnDeselect();
            openHUDref = null;
        }
    }

    //Check if mouse is on UI
    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject(PointerInputModule.kMouseLeftId))
        {
            isMouseOnUI = true;
        }
        else
        {
            isMouseOnUI = false;
        }
    }

    public void SwapHUD()
    {
        hudAnimationController.HUDswaper();
    }
}
