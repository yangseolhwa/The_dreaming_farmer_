using UnityEngine;

public class ToolInteraction : MonoBehaviour
{
    public Transform toolHolder; // 도구를 주울 위치를 지정할 빈 오브젝트

    private GameObject heldTool; // 손에 들고 있는 도구를 추적하기 위한 변수

    void Update()
    {
        // 도구를 주우기
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
            {
                GameObject tool = hit.collider.gameObject;

                // 도구에 "Tool" 태그가 있는지 확인
                if (tool.CompareTag("Tool"))
                {
                    // 도구를 주우는 위치 설정
                    Vector3 pickupPosition = toolHolder.position;

                    // 도구를 주우는 처리
                    PickupTool(tool, pickupPosition);
                }
                else
                {
                    Debug.Log("Hit object does not have the 'Tool' tag: " + tool.name);
                }
            }
            else
            {
                Debug.Log("No object hit by the raycast.");
            }
        }

        // 도구를 버리기
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // 손에 도구가 있는지 확인
            if (heldTool != null)
            {
                DropTool(heldTool);
            }
        }
    }

    void PickupTool(GameObject tool, Vector3 pickupPosition)
    {
        // 도구를 빈 오브젝트 위치로 이동시키기
        tool.transform.position = pickupPosition;

        // 도구를 활성화한다 (있으면)
        tool.SetActive(true);

        // 도구를 손에 들고 있음을 설정
        heldTool = tool;

        Debug.Log("Picked up tool: " + tool.name);
    }

    void DropTool(GameObject tool)
    {
        // 도구를 버릴 위치 설정 (플레이어 위치에서 약간 앞쪽으로)
        Vector3 dropPosition = transform.position + transform.forward * 1.5f;

        // 도구를 버리는 처리
        tool.transform.position = dropPosition;

        // 도구를 비활성화한다
        //tool.SetActive(false);

        // 손에 들고 있는 도구 변수 초기화
        heldTool = null;

        Debug.Log("Dropped tool: " + tool.name);
    }
}
