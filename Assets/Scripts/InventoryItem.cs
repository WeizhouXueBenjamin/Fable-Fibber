using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler

{
    [Header("UI")]
    [HideInInspector] public Item item;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;
    public Image image;
    public Text countText;
    private InputManager inputManager;
    private InventoryManager inventoryManager;
    Item selectedItem;

    private void Start()
    {
        inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
        inventoryManager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }


    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();
    }

    public void RefreshCount(){
        countText.text = count.ToString();
        bool textActive = count >1;
        countText.gameObject.SetActive(textActive);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        selectedItem = inventoryManager.GetSelectedItem(false);
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        inputManager.ChangeSelectSlot(inputManager.GetEventSystemRaycastResults());
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        inputManager.ChangeSelectSlot(inputManager.GetEventSystemRaycastResults());
        inputManager.CheckItem(selectedItem);
    }

    public static implicit operator InventoryItem(Item v)
    {
        throw new NotImplementedException();
    }

    public static bool IsPointerOverUIElement(List<RaycastResult> RaycastResults)
    {
        foreach (RaycastResult result in RaycastResults)
        {
            if (result.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                return true;
            }
        }
        return false;
    }

    public void CheckItem()
    {
        if (inputManager.ObjectDetection() != null && selectedItem != null)
        {
            string objectName = inputManager.ObjectDetection().name;
            string ItemName = selectedItem.name;
            //Replace Item
            if (ItemName == "Torch" && objectName == "Fire")
            {
                inventoryManager.ReplaceItem("FireTorch");
                Destroy(gameObject);
            }
            //Use Item
            if (ItemName == "FireTorch" && objectName == "Man")
            {
                inventoryManager.GetSelectedItem(true);
            }
            //Check Bubble
            else if (objectName == "Man")
            {
                StartCoroutine(inventoryManager.CallBubble("FireTorch", inputManager.ObjectDetection().transform));
            }

        }
    }
}

