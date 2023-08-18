using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public Item[] itemToPickUp;
    public GameObject InventoryItemPrefab;

    int selectedSlot = -1;

    private void Start()
    {
        ChangeSelectSlot(0);
    }

    public void ChangeSelectSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }

        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }
    public bool AddItem(Item item)
    {
        //Find empty slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }
    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(InventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    public Item GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
        if (itemInSlot != null)
        {
            Item item = itemInSlot.item;
            if (use == true)
            {
                Destroy(itemInSlot.gameObject);
            }
            return item;
        }
        return null;
    }

    public void ReplaceItem(string itemName)
    {
        foreach (Item obj in itemToPickUp)
        {
            if (obj.name == itemName)
            {
                Item replaceItem = obj;
                InventorySlot slot = inventorySlots[selectedSlot];
                GetSelectedItem(true);
                SpawnNewItem(replaceItem, slot);
            }

        }
    }
}
