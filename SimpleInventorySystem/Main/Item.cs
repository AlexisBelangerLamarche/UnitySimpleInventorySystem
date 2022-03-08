using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name;
    public int ID;// If 2 items have the same id the inventory system will just act as if their the same
    public int MaxStack;
    public Sprite icon;// Used for UI
}
