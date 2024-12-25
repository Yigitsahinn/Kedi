using UnityEditor;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
   public ItemData item;

   public void Pickup()
   {
        InventoryManager.Instance.AddItem(item);
        Destroy(gameObject);
   }

    private void OnMouseDown()
    {
        Pickup();
    }
}
