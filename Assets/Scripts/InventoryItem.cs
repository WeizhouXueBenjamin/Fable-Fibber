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
    [HideInInspector] public Transform parentAfterDrag;
    public Image image;
    public GameObject inputManager1;
    private InputManager inputManager;
    
    private void Awake()
    {
        inputManager1 = GameObject.Find("InputManager");
        inputManager = inputManager1.GetComponent<InputManager>();
    }


    public void InitialiseItem(Item newItem)
    {
        item = newItem;
        image.sprite = newItem.image;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
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
    }

    public static implicit operator InventoryItem(Item v)
    {
        throw new NotImplementedException();
    }
}
