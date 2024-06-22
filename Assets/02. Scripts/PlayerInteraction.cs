using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject heldTool; // �տ� ���� ����
    public Transform playerHandTransform; // �÷��̾� �� ��ġ (���� �ʿ�)

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
                // ������ �÷��̾� �տ� ���� ������ ����
                heldTool.transform.SetParent(playerHandTransform);
                heldTool.transform.localPosition = Vector3.zero; // �� ��ġ�� ����
            }
        }
    }

    void TryDropTool()
    {
        if (heldTool != null)
        {
            Vector3 dropPosition = transform.position + transform.forward * 2f;
            // ������ ������ ���� �߰�
            // (��: heldTool.transform.position = dropPosition)

            heldTool.transform.SetParent(null); // �տ��� ���� ����
            heldTool = null;
        }
    }
}
