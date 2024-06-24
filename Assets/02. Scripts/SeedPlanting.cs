using UnityEngine;

public class SeedPlanting : MonoBehaviour
{
    public GameObject seedPrefab; // 씨앗 프리팹
    public LayerMask groundLayer; // 땅 레이어

    void Update()
    {
        // 마우스 왼쪽 버튼 클릭 시
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 레이캐스트로 땅을 감지
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                // 클릭한 위치에 씨앗 오브젝트 생성
                Instantiate(seedPrefab, hit.point, Quaternion.identity);
            }
        }
    }
}
