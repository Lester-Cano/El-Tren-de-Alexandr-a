using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Default Object", menuName = "Inventory System/Items/Analizable")]
public class AnalizableItem : ItemObject
{
    public GameObject analizable;

    public void Awake()
    {
        type = ItemType.Analizable;
    }
}
