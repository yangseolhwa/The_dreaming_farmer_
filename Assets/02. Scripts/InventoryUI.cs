using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform slotsParent; // �κ��丮 ���Ե��� �θ� ��ü (Canvas �Ʒ��� �ִ� Grid ��)
    public GameObject slotPrefab; // ���� ������ (UI ������ ����� ���� ������)

    public static InventoryUI Instance {  get; private set; }


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
    }
}
