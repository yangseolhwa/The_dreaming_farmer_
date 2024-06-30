using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    private static InventoryManager instance;

    public static InventoryManager Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<InventoryManager>();

            return instance;
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

        Debug.Log($"Added '{itemName}' to the inventory. Current count: '{inventory[itemName]}'");

        
    }
}
