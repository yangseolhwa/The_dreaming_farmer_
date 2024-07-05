using UnityEngine;

public class InventoryToggleManager : MonoBehaviour
{
    public GameObject inventoryUI; // �κ��丮 UI GameObject

    private bool isInventoryVisible = false;
    private void Start()
    {
        inventoryUI.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleInventoryUI();
        }
    }

    private void ToggleInventoryUI()
    {
        isInventoryVisible = !isInventoryVisible;
        inventoryUI.SetActive(isInventoryVisible);
    
    }
}
