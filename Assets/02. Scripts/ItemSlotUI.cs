using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public string itemName;
    public int itemCount;
    private InventoryUI inventoryUI;
    private Image slotImage;

    private void Start()
    {
        inventoryUI = InventoryUI.Instance;
        slotImage = GetComponent<Image>();
    }

    public void OnSlotClick()
    {
        inventoryUI.SelectSlot(this);
    }

    public void SetItem(string name, int count)
    {
        itemName = name;
        itemCount = count;
    }

    public void HighlightSlot(bool highlight)
    {
        slotImage.color = highlight ? Color.yellow : Color.white;
    }
}
