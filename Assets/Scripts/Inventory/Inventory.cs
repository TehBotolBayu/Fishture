using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<FishBase> items = new List<FishBase>();
    public int inventorySize = 20;

    public void AddItem(FishBase item)
    {
        if (items.Count < inventorySize)
        {
            items.Add(item);
            Debug.Log($"Added {item.nama} to inventory.");
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }

    public void RemoveItem(FishBase item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Debug.Log($"Removed {item.nama} from inventory.");
        }
        else
        {
            Debug.Log("Item not found in inventory!");
        }
    }
}
