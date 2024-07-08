using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float rotateSpeed = 2.5f;
    public float jumpPower = 5f;

    private bool isJumping = false;
    private bool isMoving = false;

    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        Move();
        Jump();
    }


    public void Move()
    {
        float mouseX = Input.GetAxis("Mouse X");

        // WASD 키 입력 받기
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        if (CameraManager.Instance.IsCameraActive)
        {
            Vector3 rotateDirection = new Vector3(0f, mouseX * rotateSpeed, 0f);
            transform.Rotate(rotateDirection);
        }
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            SoundManager.Instance.PlayJumpSFX();
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("FarmSoil"))
        {
            isJumping = false;
        }
    }

}
