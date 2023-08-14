using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private UIInventoryPage _inventoryUI;

    public int inventorySize = 5;

    public void Start()
    {
        _inventoryUI.Hide();
        _inventoryUI.InitializeInventoryUI(inventorySize);
    }

    public void InventoryButtonFunction()
    {
        if (_inventoryUI.isActiveAndEnabled == false)
        {
            _inventoryUI.Show();
        }
        else
        {
            _inventoryUI.Hide();
        }
    }
}
