using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform slotsParent; // �κ��丮 ���Ե��� �θ� ��ü (Canvas �Ʒ��� �ִ� Grid ��)
    public GameObject slotPrefab; // ���� ������ (UI ������ ����� ���� ������)
    public Button deleteButton;

    public static InventoryUI Instance {  get; private set; }

    private Dictionary<string, GameObject> slotObjects = new Dictionary<string, GameObject>();

    private ItemSlot selectedSlot;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    // ���Ե��� �ʱ�ȭ�ϴ� �޼���
    public void InitializeInventory(Dictionary<string, int> items)
    {
        ClearSlots();

        // �κ��丮 �����͸� ������� UI ���Ե��� ����
        foreach (var item in items)
        {
            CreateSlot(item.Key, item.Value);
        }
    }

    // UI ������ �����ϴ� �޼���
    private void CreateSlot(string itemName, int itemCount)
    {
        GameObject slotObject = Instantiate(slotPrefab, slotsParent);
        TMP_Text[] tmpTexts = slotObject.GetComponentsInChildren<TMP_Text>();

        foreach (var tmpText in tmpTexts)
        {
            if (tmpText.name == "NameText")
            {
                tmpText.text = itemName;
            }
            else if (tmpText.name == "QuantityText")
            {
                tmpText.text = itemCount.ToString();
            }
        }

        slotObjects[itemName] = slotObject;
    }

    //���� ������ �ʱ�ȭ�ϴ� �޼���
    private void ClearSlots()
    {
        foreach (Transform child in slotsParent)
        {
            Destroy(child.gameObject);
        }

        slotObjects.Clear();
    }

    // ���� ������ ������Ʈ�ϴ� �޼���
    public void UpdateItem(string itemName, int itemCount)
    {
        if (slotObjects.ContainsKey(itemName))
        {
            TMP_Text[] tmpTexts = slotObjects[itemName].GetComponentsInChildren<TMP_Text>();

            foreach (var tmpText in tmpTexts)
            {
                if (tmpText.name == "QuantityText")
                {
                    tmpText.text = itemCount.ToString();
                }
            }
        }
        else
        {
            CreateSlot(itemName, itemCount);
        }
    }

    public void SelectSlot(ItemSlot slot)
    {
        if (selectedSlot != null)
        {
            selectedSlot.HighlightSlot(false);
        }

        selectedSlot = slot;
        selectedSlot.HighlightSlot(true);
    }

    private void DeleteSelectedItem()
    {
        if (selectedSlot != null)
        {
            InventoryManager.Instance.RemoveItem(selectedSlot.itemName);
            selectedSlot = null;
        }
    }

}
