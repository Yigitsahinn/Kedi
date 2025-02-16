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
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject suspectPanel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryPanel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            suspectPanel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            inventoryPanel.SetActive(false);
            suspectPanel.SetActive(false);
        }


    }
    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(ItemData item)
    {
        Items.Add(item);

        GameObject obj = Instantiate(inventoryItem, itemContent);
        var itemNameText = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
        var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

        itemNameText.text = item.itemName;
        itemIcon.sprite = item.itemIcon;

        SuspectManager.instance.RemoveSuspects(item);
    }


}
