using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public InventoryManager inventoryManager;
    void Awake()
    {
    }
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            string clickedObject = ObjectDetection();
            Item selectedItem = inventoryManager.GetSelectedItem(false);
            if (selectedItem != null)
            {
                string ItemName = selectedItem.name;
                Debug.Log(clickedObject + ItemName);
                if (ItemName == "Torch" && clickedObject == "Fire")
                {
                    inventoryManager.ReplaceItem("FireTorch");


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
}



