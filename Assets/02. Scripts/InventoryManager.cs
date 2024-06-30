using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Dictionary<string, int> inventory = new Dictionary<string, int>();

    // �������� �κ��丮�� �߰��ϴ� �޼���
    public void AddItem(string itemName)
    {
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName]++;
            
        }
        else
        {
            inventory.Add(itemName, 1);
        }

        InventoryUI.Instance.InitializeInventory(inventory);

        Debug.Log($"Added '{itemName}' to the inventory. Current count: '{inventory[itemName]}'");

        
    }
}
