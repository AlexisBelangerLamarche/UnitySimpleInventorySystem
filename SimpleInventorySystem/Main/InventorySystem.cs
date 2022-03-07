using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class Slot // Class so i can store multiple value in an array
{
    public bool HasItem;
    public int ItemId;      //
    public int Ammount;
    public int ItemMaxStack;// Copy the item class so its possible to delete the object attached to it
    public Sprite ItemIcon; //
}

public class InventorySystem : MonoBehaviour
{
    public Slot[] slots;// Item slots (change in inspector)

    public bool AddItem(Item item, int ammount)// Add {ammount} of {item}
    {
        bool Success = false;// The return value. Will stay false if the function failed to add the {item}

        foreach (Slot slot in slots)// This loop is to check if a similar {item} exist in the inventory. If so, add it to the stack (of item).
        {
            if (item.MaxStack < ammount)// If the {ammount} to add is bigger than the maximum stack of the {item} dont allow it to continue
                break;

            if (!slot.HasItem)// if theres no item in this slot, continue.
                continue;

            if (slot.ItemId == item.ID && slot.Ammount < slot.ItemMaxStack && (slot.Ammount + ammount) <= slot.ItemMaxStack)// Too lazy to comment that one
            {
                slot.Ammount += ammount;// Add the item {ammount}
                Success = true;// We are succesfull at adding the {item}
                return Success;
            }

        }

        foreach (Slot slot in slots)// This loop is for when theres is no similar {item} in the inventory. Itll just add it to the first avalaible slot.
        {
            if (item.MaxStack < ammount)// If the {ammount} to add is bigger than the maximum stack of the {item} dont allow it to continue
                break;

            if (!slot.HasItem)// If theres no item in the slot add {item} to it. Copy everything from the class so its possible to delete the object attached to it.
            {
                slot.ItemId = item.ID;
                slot.ItemMaxStack = item.MaxStack;
                slot.ItemIcon = item.icon;
                slot.Ammount = ammount;
                slot.HasItem = true;
                Success = true;
                break;
            }

            if (slot.ItemId == item.ID && slot.Ammount < slot.ItemMaxStack && (slot.Ammount + ammount) <= slot.ItemMaxStack)
            {
                slot.Ammount += ammount;
                Success = true;
                break;
            }
        }

        return Success; // 10/10 code
    }

    public void RemoveItem(Item item, int ammount)// Removes an item specified by {item} by {ammount}
    {
        foreach (Slot slot in slots)
        {
            if (!slot.HasItem)
                continue;

            if (slot.ItemId == item.ID)
            {
                slot.Ammount -= ammount;

                if (slot.Ammount <= 0)// If the the ammount of item as reached 0, Reset the slot.
                {
                    slot.Ammount = 0;
                    slot.HasItem = false;
                    slot.ItemIcon = null;
                    slot.ItemMaxStack = 0;
                    slot.ItemId = 0;
                }

                break;
            }
        }
    }

    public void RemoveItem(int slotNumber, int ammount)// Function overload (is that how you call it?) of remove item. This time it uses the slot number and not a specified item. (I guess i decided to add warning now)
    {
        if (slotNumber > slots.Length - 1)
        {
            Debug.LogWarning("Slot out of bound. No removing done.");
            return;
        }

        if (slotNumber < 0)
        {
            Debug.LogWarning("Arrays dont have negative numbers. Unless they do, But id be suprised.");
            return;
        }

        if (slots[slotNumber].HasItem == false)
        {
            Debug.LogWarning("This slot has no item. No removing done.");
            return;
        }

        slots[slotNumber].Ammount -= ammount;
        if (slots[slotNumber].Ammount <= 0)
        {
            slots[slotNumber].Ammount = 0;
            slots[slotNumber].HasItem = false;
            slots[slotNumber].ItemIcon = null;
            slots[slotNumber].ItemMaxStack = 0;
            slots[slotNumber].ItemId = 0;
        }
    }
}
