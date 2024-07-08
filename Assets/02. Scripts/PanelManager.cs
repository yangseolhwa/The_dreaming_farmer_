using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject panel;
    private bool isPanelActive = false;

    void Update()
    {
        // �г��� ����ϱ� ���� 'O' Ű�� ���� ������ ShowPanel �޼��� ȣ��
        if (Input.GetKeyDown(KeyCode.O))
        {
            TogglePanel();
        }
    }

    private void TogglePanel()
    {
        // �г��� Ȱ��ȭ�Ǿ� �ִ��� Ȯ��
        if (panel.activeSelf)
        {
            // �г��� Ȱ��ȭ�Ǿ� �ִٸ� ��Ȱ��ȭ
            panel.SetActive(false);
            isPanelActive = false;
            //CameraManager.Instance.SetCameraActive(true);
        }
        else
        {
            // �г��� ��Ȱ��ȭ�Ǿ� �ִٸ� Ȱ��ȭ
            panel.SetActive(true);
            isPanelActive = true;
            //CameraManager.Instance.SetCameraActive(false);
        }
    }
}
