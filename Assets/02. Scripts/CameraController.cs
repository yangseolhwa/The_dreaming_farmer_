using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform; // 플레이어 캐릭터의 Transform

    public float cameraSensitivity = 2f;
    public float maxVerticalAngle = 100f; // 최대 위 아래 회전 각도
    public float minVerticalAngle = -30f; // 최소 위 아래 회전 각도

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 플레이어 캐릭터의 회전과 카메라의 회전을 분리하여 처리
        playerTransform.Rotate(Vector3.up * mouseX * cameraSensitivity);

        // 위 아래 회전 각도 제한
        float newRotationX = transform.localEulerAngles.x - mouseY * cameraSensitivity;
        newRotationX = Mathf.Clamp(newRotationX, minVerticalAngle, maxVerticalAngle);

        // 최대 각도를 넘어가면 끊기지 않고 최대 각도에 계속 머무르도록 수정
        if (newRotationX > maxVerticalAngle)
            newRotationX = maxVerticalAngle;
        else if (newRotationX < minVerticalAngle)
            newRotationX = minVerticalAngle;

        transform.localEulerAngles = new Vector3(newRotationX, transform.localEulerAngles.y, 0f);
    }
}
