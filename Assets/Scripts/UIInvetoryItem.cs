using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIInvetoryItem : MonoBehaviour
{
    [SerializeField] private Image itemImage;

    private bool empty = true;

    public void Awake()
    {
        ResetData();
    }

    public void ResetData()
    {
        this.itemImage.gameObject.SetActive(false);
        empty = true;
    }

    public void SetData(Sprite sprite)
    {
        this.itemImage.gameObject.SetActive(true);
        this.itemImage.sprite = sprite;
        empty = false;
    }
}
