using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Transform handPosition; // �� ��ġ�� ��Ÿ���� Transform

    private GameObject pickedObject; // �÷��̾ ���� ��� �ִ� ������Ʈ ����

    void Update()
    {
        // E Ű�� ���� ������Ʈ�� �ݱ� �õ�
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickupObject();
        }

        // Q Ű�� ���� ������Ʈ ������
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropObject();
        }
    }

    void TryPickupObject()
    {
        // �ֺ��� �ִ� ��� Collider�� �������� (���⼭�� �÷��̾� �ֺ����� ã��)
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f); // �ݰ� 2 ����Ƽ ���� ��

        foreach (Collider col in colliders)
        {
            // �θ� ������Ʈ�� hoe �±װ� �ִ��� Ȯ��
            Transform parentTransform = col.transform.parent;
            if (parentTransform != null && parentTransform.CompareTag("Tool"))
            {
                // �̹� ������Ʈ�� ��� �ִ� ��� ����
                if (pickedObject != null)
                    return;

                // �θ� ������Ʈ�� ���
                pickedObject = parentTransform.gameObject;

                // HandlePosition �±׸� ���� �ڽ� ������Ʈ�� ã��
                Transform handlePosition = null;
                foreach (Transform child in pickedObject.transform)
                {
                    if (child.CompareTag("HandlePosition"))
                    {
                        handlePosition = child;
                        break;
                    }
                }

                if (handlePosition == null)
                {
                    Debug.LogWarning("HandlePosition �±׸� ���� �ڽ� ������Ʈ�� ã�� �� �����ϴ�.");
                    return;
                }

                // ������ ��ġ�� �� ��ġ�� �̵�
                pickedObject.transform.parent = handPosition; // �� ��ġ�� �ڽ����� ����

                // ���� ȸ���� �����ϰ� ������ ��ġ�� �� ��ġ�� ���߱�
                Vector3 originalPosition = pickedObject.transform.position; // ������Ʈ�� ���� ��ġ ����
                Quaternion originalRotation = pickedObject.transform.rotation; // ������Ʈ�� ���� ȸ���� ����

                pickedObject.transform.rotation = handPosition.rotation; // �� ��ġ�� ���� ȸ������ ����

                Vector3 offset = handlePosition.position - pickedObject.transform.position;
                pickedObject.transform.position = handPosition.position - offset; // ������ ��ġ�� �� ��ġ�� �̵�

                // ���� ȸ���� ����
                pickedObject.transform.rotation = originalRotation;

                // Rigidbody�� ������ kinematic���� �����Ͽ� ���� ������ ���� �ʵ��� ��
                Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
                if (rb != null)
                    rb.isKinematic = true;

                // ���⼭ �ٸ� �۾��� ������ �� ���� (��: ������Ʈ Ȱ��ȭ/��Ȱ��ȭ, ������ ó�� ��)

                break; // �ϳ��� ���
            }
        }
    }

    void DropObject()
    {
        if (pickedObject != null)
        {
            // ������Ʈ�� �� ��ġ���� ����� �߷� ������ �޵��� ����
            pickedObject.transform.parent = null;
            Rigidbody rb = pickedObject.GetComponent<Rigidbody>();
            if (rb != null)
                rb.isKinematic = false; // �߷� ���� �޵��� ����

            pickedObject = null; // �÷��̾ ��� �ִ� ������Ʈ �ʱ�ȭ
        }
    }
}
