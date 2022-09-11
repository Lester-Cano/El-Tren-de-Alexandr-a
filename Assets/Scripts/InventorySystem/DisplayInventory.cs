using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{

    public InventoryObject inventory;

    public int xStart;
    public int yStart;
    public int spaceInXBetweenItems;
    public int column;
    public int spaceInYBetweenItems;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();


    private void Start()
    {
        CreateDisplay();
    }

    private void Update()
    {
        UpdateDisplay();
    }


    void CreateDisplay()
    {
        for (int i = 0; i < inventory.container.Count; i++)
        {
            var obj = Instantiate(inventory.container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            itemsDisplayed.Add(inventory.container[i], obj);
        }
    }

    void UpdateDisplay()
    {
        for (int i = 0; i < inventory.container.Count; i++)
        {

            if (itemsDisplayed.ContainsKey(inventory.container[i]))
            {

            }
            else
            {
                var obj = Instantiate(inventory.container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                itemsDisplayed.Add(inventory.container[i], obj);
            }

        }
    }

    public Vector3 GetPosition(int i)
    {
        return new Vector3(xStart + (spaceInXBetweenItems * (i % column)), yStart + (-spaceInYBetweenItems * (i / column)), 0f);
    }



}
