using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemToPickUp;

    public void PickUpItem(int id)
    {
        bool result = inventoryManager.AddItem(itemToPickUp[id]);
        if (result == true)
        {
            Debug.Log("Item added");
        }
        else
        { Debug.Log("Item not added"); }
    }

    public void GetSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(false);
        if (receivedItem != null)
        {
            Debug.Log("Received item: " + receivedItem);
        }

        else
        {
            Debug.Log("No item received!");
        }

    }

    public void UseSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(true);
        if (receivedItem != null)
        {
            Debug.Log("Used item: " + receivedItem);
        }

        else
        {
            Debug.Log("No item used!");
        }

    }

}
