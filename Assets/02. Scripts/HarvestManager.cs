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

        float jumpHeight = 0.5f; // 위로 튀어오를 높이
        float jumpDuration = 0.5f; // 튀어오르는 시간

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

        Destroy(gameObject); // 애니메이션 종료 후 게임 오브젝트 파괴
    }
}
