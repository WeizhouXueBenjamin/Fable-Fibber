using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public Item[] itemToPickUp;
    public GameObject InventoryItemPrefab;
    [SerializeField] private GameObject IdeaBubble;
    [SerializeField] private ReceivedItem receivedItem;


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
        //Find empty slot with count lower than max
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null &&
            itemInSlot.item == item &&
            itemInSlot.count <= 4 &&
            itemInSlot.item.stackable == true)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }
        //Find empty slot
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                receivedItem.ReceiveItem(item.image);
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
                receivedItem.ReceiveItem(obj.image);
            }

        }
    }

    public IEnumerator CallBubble(string itemName, Transform transform)
    {
        float time = 3f;
        float timer = 0f;
        foreach (Item obj in itemToPickUp)
        {
            if (obj.name == itemName)
            {
                GameObject bubble = Instantiate(IdeaBubble, transform.position + (transform.up * 2.7f) + (transform.right * 0.5f), transform.rotation);
                bubble.GetComponent<SpriteRenderer>().sprite = obj.image;

                while (timer < time)
                {
                    timer += Time.deltaTime;
                    yield return null;
                }
                Destroy(bubble);


            }
        }
    }
}
