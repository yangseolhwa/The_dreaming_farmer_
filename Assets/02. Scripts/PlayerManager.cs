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
        // WASD Ű �Է� �ޱ�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);

        // �̵� ���⿡ ���� ĳ���� �̵�
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void Rotation()
    {
        // ���콺 X �����ӿ� ���� ĳ���͸� ȸ����Ű�� �Լ�
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
