using UnityEngine;

public class ToolInteraction : MonoBehaviour
{
    public Transform toolHolder; // ������ �ֿ� ��ġ�� ������ �� ������Ʈ

    private GameObject heldTool; // �տ� ��� �ִ� ������ �����ϱ� ���� ����

    void Update()
    {
        // ������ �ֿ��
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
            {
                GameObject tool = hit.collider.gameObject;

                // ������ "Tool" �±װ� �ִ��� Ȯ��
                if (tool.CompareTag("Tool"))
                {
                    // ������ �ֿ�� ��ġ ����
                    Vector3 pickupPosition = toolHolder.position;

                    // ������ �ֿ�� ó��
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

        // ������ ������
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // �տ� ������ �ִ��� Ȯ��
            if (heldTool != null)
            {
                DropTool(heldTool);
            }
        }
    }

    void PickupTool(GameObject tool, Vector3 pickupPosition)
    {
        // ������ �� ������Ʈ ��ġ�� �̵���Ű��
        tool.transform.position = pickupPosition;

        // ������ Ȱ��ȭ�Ѵ� (������)
        tool.SetActive(true);

        // ������ �տ� ��� ������ ����
        heldTool = tool;

        Debug.Log("Picked up tool: " + tool.name);
    }

    void DropTool(GameObject tool)
    {
        // ������ ���� ��ġ ���� (�÷��̾� ��ġ���� �ణ ��������)
        Vector3 dropPosition = transform.position + transform.forward * 1.5f;

        // ������ ������ ó��
        tool.transform.position = dropPosition;

        // ������ ��Ȱ��ȭ�Ѵ�
        //tool.SetActive(false);

        // �տ� ��� �ִ� ���� ���� �ʱ�ȭ
        heldTool = null;

        Debug.Log("Dropped tool: " + tool.name);
    }
}
