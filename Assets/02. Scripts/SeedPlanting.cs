using UnityEngine;

public class SeedPlanting : MonoBehaviour
{
    public GameObject seedPrefab; // ���� ������
    public LayerMask groundLayer; // �� ���̾�

    void Update()
    {
        // ���콺 ���� ��ư Ŭ�� ��
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ����ĳ��Ʈ�� ���� ����
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                // Ŭ���� ��ġ�� ���� ������Ʈ ����
                Instantiate(seedPrefab, hit.point, Quaternion.identity);
            }
        }
    }
}
