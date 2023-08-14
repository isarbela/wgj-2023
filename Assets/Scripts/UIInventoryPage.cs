using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UIInvetoryItem;

public class UIInventoryPage : MonoBehaviour
{
    [SerializeField] private UIInvetoryItem itemPrefab;
    [SerializeField] private RectTransform contentPanel;

    List<UIInvetoryItem> _listOfItems = new List<UIInvetoryItem>();

    public void InitializeInventoryUI(int inventorysize)
    {
        
        for (int i = 0; i < inventorysize; i++)
        {
            UIInvetoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
            uiItem.transform.SetParent(contentPanel);
            _listOfItems.Add(uiItem);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
    
}
