using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<ItemData> Items = new List<ItemData>();
    [SerializeField] private Transform itemContent;
    [SerializeField] private GameObject inventoryItem;
    [SerializeField] private GameObject panel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            panel.SetActive(true);
            ListItems();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(false);
        }
    }
    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(ItemData item)
    {
        Items.Add(item);
    }

    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.itemIcon;
        }
    }
}
