using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Item ItemBeingHovered;

    void Update()
    {
        u_CamRay();

        CheckInput();
    }

    void CheckInput()
    {


        if (Input.GetMouseButtonDown(0))
        {
            if (ItemBeingHovered != null)// If we are hovering over an item
            {
                if (gameObject.GetComponent<InventorySystem>().AddItem(ItemBeingHovered, 1))// Pickup the object currently hovered over
                {
                    Destroy(ItemBeingHovered.gameObject);// If we succesfully grap the item (AddItem will return true if it doesnt fail at adding the item to the inventory) Destroy the object.
                }
            }
        }

        if (Input.GetMouseButtonUp(1)) // Remove 1 object your currently hovering over from the inventory
        {
            if (ItemBeingHovered != null)
            {
                gameObject.GetComponent<InventorySystem>().RemoveItem(ItemBeingHovered, 1);
            }
        }

        if (Input.GetMouseButtonUp(2)) // Remove 1 object from the first inventory slot
        {
            if (ItemBeingHovered != null)
            {
                gameObject.GetComponent<InventorySystem>().RemoveItem(0, 1);
            }
        }

    }

    void u_CamRay()
    {
        RaycastHit hit;// What the ray hits
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);// the ray itself wich is from the camera to the mouse on the terrain
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);// Debug so i can see the ray in the scene


        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.GetComponent<Item>() != null)// If what with hit with the raycast has an Item component
            {
                ItemBeingHovered = hit.transform.gameObject.GetComponent<Item>();// Assign it to {ItemBeingHovered}
            }
            else
            {
                ItemBeingHovered = null;// Else set it to null
            }
        }
    }
}
