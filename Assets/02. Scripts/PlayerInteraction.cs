using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject heldTool; // 손에 잡힌 도구
    public Transform playerHandTransform; // 플레이어 손 위치 (수정 필요)

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickUpTool();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            TryDropTool();
        }
    }

    void TryPickUpTool()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("Tool"))
            {
                heldTool = hitObject;
                // 도구를 플레이어 손에 잡힌 도구로 설정
                heldTool.transform.SetParent(playerHandTransform);
                heldTool.transform.localPosition = Vector3.zero; // 손 위치에 고정
            }
        }
    }

    void TryDropTool()
    {
        if (heldTool != null)
        {
            Vector3 dropPosition = transform.position + transform.forward * 2f;
            // 도구를 버리는 로직 추가
            // (예: heldTool.transform.position = dropPosition)

            heldTool.transform.SetParent(null); // 손에서 도구 제거
            heldTool = null;
        }
    }
}
