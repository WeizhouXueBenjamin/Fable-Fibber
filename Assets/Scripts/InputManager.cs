using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public GameObject toolbar;
    Vector2 tarPos;
    Vector2 orgPos;
    float width;
    public float speed;
    RectTransform rt;

    private void Awake()
    {
        rt = toolbar.GetComponent<RectTransform>();
        orgPos = rt.transform.position;
        width = rt.rect.width;
        tarPos = new(orgPos.x - width, orgPos.y);
    }
    void Update()
    {

        //Debug.Log(IsPointerOverUIElement(GetEventSystemRaycastResults()));
        float step = speed * Time.deltaTime;
        if (IsPointerOverUIElement(GetEventSystemRaycastResults()) == true)
        {
            toolbar.transform.position = Vector2.MoveTowards(toolbar.transform.position, tarPos, step);
        }
        else
        {
            toolbar.transform.position = Vector2.MoveTowards(toolbar.transform.position, orgPos, step);
        }

        //LeftClick
        if (Input.GetMouseButtonDown(0))
        {
            Item selectedItem = inventoryManager.GetSelectedItem(false);
            if (selectedItem != null)
            {
                string objectName = ObjectDetection();
                string ItemName = selectedItem.name;
                Debug.Log(objectName + ItemName);
                if (ItemName == "Torch" && objectName == "Fire")
                {
                    inventoryManager.ReplaceItem("FireTorch");
                }
                if (objectName == "Man")
                {
                    Debug.Log("1");
                    inventoryManager.CallBubble("Torch");
                }
            }
        }
    }
    public string ObjectDetection()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
        if (hit.collider != null)
        {
            string clickedObject = hit.collider.gameObject.name;
            return clickedObject;
        }
        return null;

    }
    ///Returns 'true' if we touched or hovering on Unity UI element.
    public static bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaysastResults)
    {
        for (int index = 0; index < eventSystemRaysastResults.Count; index++)
        {
            RaycastResult curRaysastResult = eventSystemRaysastResults[index];

            if (curRaysastResult.gameObject.layer == LayerMask.NameToLayer("UI"))
                return true;
        }

        return false;
    }
    ///Gets all event systen raycast results of current mouse or touch position.
    public List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        //foreach (var eventData2 in raycastResults) { Debug.Log(eventData2.ToString()); }
        return raycastResults;
    }

    public void ChangeSelectSlot(List<RaycastResult> raycastResults)
    {
        foreach (var eventData in raycastResults)
        {
            string objectString = eventData.ToString();
            if (objectString.Contains("InventorySlot") == true)
            {
                int index = int.Parse(Regex.Match(objectString, @"\d+").Value);
                Debug.Log(index);
                inventoryManager.ChangeSelectSlot(index);
            }
        }
    }
}



