using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public Inventory inventory;
    InventorySlot[] slots;

    void Start()
    {
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        UpdateUI();
    }

    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddFish(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void AddItem(FishBase item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].icon.sprite == null)
            {
                slots[i].AddFish(item);
                return;
            }
        }
    }

    public void RemoveItem(FishBase item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].icon.sprite == item.image)
            {
                slots[i].ClearSlot();
                return;
            }
        }
    }
}
