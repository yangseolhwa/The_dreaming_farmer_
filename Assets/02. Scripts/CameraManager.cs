using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    public float sensitivity = 3.5f;
    public Transform playerTransform;

    private float rotationX = 0;

    private bool isCameraActive = true;

    public bool IsCameraActive { get { return isCameraActive; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    

    void Start()
    {

    }

    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        if (isCameraActive)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;

            rotationX -= Input.GetAxis("Mouse Y") * sensitivity;
            rotationX = Mathf.Clamp(rotationX, -90f, 30f);

            transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            playerTransform.Rotate(Vector3.up * mouseX);
        }
       
    }


    public void SetCameraActive(bool isActive)
    {
        Debug.Log("SetCameraActive called with: " + isActive);
        isCameraActive = isActive;
        SetCursorState();
    }

    public void SetCursorState()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
