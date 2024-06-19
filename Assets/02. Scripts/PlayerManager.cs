using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 2f;
    public float jumpPower = 5f;
    private bool isJumping = false;
    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        Jump();
        Rotation();
    }


    public void Move()
    {
        // WASD 키 입력 받기
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);

        // 이동 방향에 따라 캐릭터 이동
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void Rotation()
    {
        // 마우스 X 움직임에 따라 캐릭터를 회전시키는 함수
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 rotation = new Vector3(0f, mouseX, 0f);
        transform.Rotate(rotation * rotateSpeed);
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
