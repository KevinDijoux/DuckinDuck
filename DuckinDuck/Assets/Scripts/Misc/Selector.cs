using UnityEngine;
using UnityEngine.EventSystems;

public class Selector : MonoBehaviour
{
    public GameObject towerHUD;
    public GameObject usineHUD;
    [SerializeField] LayerMask interactibleLayer;
    private HUDWhenSelect HUDSelect;
    private bool isMouseOnUI;
    [SerializeField] private Transform anchor = null;
    public bool IsMouseOnUI => isMouseOnUI;

    public void Select()
    {
        //Debug.Log("select work");
        RaycastToOpenHUDRef();
    }

    private void RaycastToOpenHUDRef()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, float.MaxValue))
        {
            if (HUDSelect != null)
            {
                HUDSelect.OnDeselect();
                HUDSelect = null;
            }

            if (hit.transform.GetComponent<HUDWhenSelect>())
            {
                HUDSelect = hit.transform.gameObject.GetComponent<HUDWhenSelect>();
                HUDSelect.OnSelect();
            }            
        }
        else if (HUDSelect != null && !isMouseOnUI)
        {
            HUDSelect.OnDeselect();
            HUDSelect = null;
        }
    }

    //Check if mouse is on UI
    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject(PointerInputModule.kMouseLeftId))
        {
            //Debug.Log("OnScreen");
            isMouseOnUI = true;
        }
        else
        {
            //Debug.Log("OffScreen");
            isMouseOnUI = false;
        }
    }
}
