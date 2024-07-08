using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject panel;
    private bool isPanelActive = false;

    void Update()
    {
        // 패널을 토글하기 위해 'O' 키를 누를 때마다 ShowPanel 메서드 호출
        if (Input.GetKeyDown(KeyCode.O))
        {
            TogglePanel();
        }
    }

    private void TogglePanel()
    {
        // 패널이 활성화되어 있는지 확인
        if (panel.activeSelf)
        {
            // 패널이 활성화되어 있다면 비활성화
            panel.SetActive(false);
            isPanelActive = false;
            //CameraManager.Instance.SetCameraActive(true);
        }
        else
        {
            // 패널이 비활성화되어 있다면 활성화
            panel.SetActive(true);
            isPanelActive = true;
            //CameraManager.Instance.SetCameraActive(false);
        }
    }
}
