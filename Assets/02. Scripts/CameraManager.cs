using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 2.0f;
    public Transform playerTransform;

    private float rotationX = 0;

    void Start()
    {
        
    }

    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;

        rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90f, 30f);

        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        playerTransform.Rotate(Vector3.up * mouseX);
    }
}
