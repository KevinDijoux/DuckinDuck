using UnityEngine;
using UnityEngine.EventSystems;


public class Selector : MonoBehaviour
{

    private HUDWhenSelect HUDSelect;
    private bool isMouseOnUI;
    [SerializeField] private Transform anchor = null;
    private GameObject location = null;

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
                anchor = null;
            }

            if (hit.transform.GetComponent<HUDWhenSelect>())
            {
                
                HUDSelect = hit.transform.gameObject.GetComponent<HUDWhenSelect>();
                anchor = hit.transform.gameObject.GetComponent<HUDWhenSelect>().transform;
                location = hit.transform.gameObject.GetComponent<HUDWhenSelect>().gameObject;

                GameManager.Instance.UIManager.SetAnchor(anchor);
                GameManager.Instance.UIManager.SetLocation(location);


                HUDSelect.OnSelect();

            }
        }
        else if (HUDSelect != null && !isMouseOnUI)
        {
            HUDSelect.OnDeselect();
            HUDSelect = null;
            anchor = null;
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
