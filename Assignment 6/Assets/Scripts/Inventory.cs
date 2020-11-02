/*****************************************************************************
// File Name :         Inventory.cs
// Author :            Kyle Grenier
// Creation Date :     10/28/2020
// Assignment:         Assignment 6
// Brief Description : Defines behaviour for the inventory.
*****************************************************************************/

using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private InventoryItem item;

    [SerializeField]
    private List<InventoryItem> inventory;
}
