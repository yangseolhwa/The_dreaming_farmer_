using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform; // �÷��̾� ĳ������ Transform

    public float cameraSensitivity = 2f;
    public float maxVerticalAngle = 100f; // �ִ� �� �Ʒ� ȸ�� ����
    public float minVerticalAngle = -30f; // �ּ� �� �Ʒ� ȸ�� ����

    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // �÷��̾� ĳ������ ȸ���� ī�޶��� ȸ���� �и��Ͽ� ó��
        playerTransform.Rotate(Vector3.up * mouseX * cameraSensitivity);

        // �� �Ʒ� ȸ�� ���� ����
        float newRotationX = transform.localEulerAngles.x - mouseY * cameraSensitivity;
        newRotationX = Mathf.Clamp(newRotationX, minVerticalAngle, maxVerticalAngle);

        // �ִ� ������ �Ѿ�� ������ �ʰ� �ִ� ������ ��� �ӹ������� ����
        if (newRotationX > maxVerticalAngle)
            newRotationX = maxVerticalAngle;
        else if (newRotationX < minVerticalAngle)
            newRotationX = minVerticalAngle;

        transform.localEulerAngles = new Vector3(newRotationX, transform.localEulerAngles.y, 0f);
    }
}
