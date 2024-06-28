using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform slotsParent; // 인벤토리 슬롯들의 부모 객체 (Canvas 아래에 있는 Grid 등)
    public GameObject slotPrefab; // 슬롯 프리팹 (UI 슬롯을 만들기 위한 프리팹)

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

    // 슬롯들을 초기화하는 메서드
    public void InitializeInventory(Dictionary<string, int> items)
    {
        // 인벤토리 데이터를 기반으로 UI 슬롯들을 생성
        foreach (var item in items)
        {
            CreateSlot(item.Key, item.Value);
        }
    }

    // UI 슬롯을 생성하는 메서드
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
