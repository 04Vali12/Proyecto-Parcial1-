using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryO : MonoBehaviour
{
    public bool InventoryOEnabled { get; set; }

    public GameObject inventoryO;
    private int allSlots;
    private GameObject[] slot;
    public GameObject slotHolder;

    void Start()
    {
        allSlots = slotHolder.transform.childCount;
        slot = new GameObject[allSlots];

        // Initialize slots
        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            Slot slotComponent = slot[i].GetComponent<Slot>();
            if (slotComponent != null && slotComponent.item == null)
            {
                slotComponent.empty = true;
            }
        }
    }

    void Update()
    {
        // Toggle inventory visibility
        if (Input.GetKeyDown(KeyCode.Q))
        {
            InventoryOEnabled = !InventoryOEnabled;
            inventoryO.SetActive(InventoryOEnabled);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("Item"))
        {
            GameObject itemRecogido = other.gameObject;
            Item item = itemRecogido.GetComponent<Item>();
            if (item != null)
            {
                AddItem(itemRecogido, item.itemID, item.Type, item.Description, item.Icon);
            }
        }
    }

    public void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            Slot slotComponent = slot[i].GetComponent<Slot>();
            if (slotComponent != null && slotComponent.empty)
            {
                slotComponent.item = itemObject;
                slotComponent.ID = itemID;
                slotComponent.type = itemType;
                slotComponent.description = itemDescription;
                slotComponent.icon = itemIcon;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slotComponent.UpdateSlot();

                slotComponent.empty = false;

                return; // Exit the method after adding the item
            }
        }
    }
}

