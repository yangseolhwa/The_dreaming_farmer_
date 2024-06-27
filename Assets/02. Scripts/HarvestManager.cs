using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class HarvestManager : MonoBehaviour
{
    private bool isPulled = false;
    private InventoryManager inventoryManager;

    private void Awake()
    {
        inventoryManager = GetComponent<InventoryManager>();
    }

    public void OnMouseDown()
    {
        if (!isPulled)
        {
            StartCoroutine(PullCarrot());
        }
    }

    private IEnumerator PullCarrot()
    {
        isPulled = true;

        float jumpHeight = 0.5f; // ���� Ƣ����� ����
        float jumpDuration = 0.5f; // Ƣ������� �ð�

        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + Vector3.up * jumpHeight;

        float elapsedTime = 0f;

        while (elapsedTime < jumpDuration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, elapsedTime / jumpDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        InventoryManager.Instance.AddItem("Carrot");

        Destroy(gameObject); // �ִϸ��̼� ���� �� ���� ������Ʈ �ı�
    }
}
