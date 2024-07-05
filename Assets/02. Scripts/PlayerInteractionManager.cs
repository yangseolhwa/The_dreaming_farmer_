using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    public static PlayerInteractionManager Instance {  get; private set; }

    public GameObject heldTool; // �տ� ���� ����
    public Transform playerHandTransform; // �÷��̾� �� ��ġ

    public bool held = false;

    [SerializeField]
    private Rigidbody rb;
    private Quaternion prefabRotation;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickUpObject();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            TryDropObject();
        }
    }

    void TryPickUpObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("Interactable") && !held)
            {

                heldTool = hitObject;
                // ������ �÷��̾� �տ� ���� ������ ����

                rb = heldTool.GetComponent<Rigidbody>();
                
                rb.useGravity = false;
                rb.isKinematic = true;

                prefabRotation = heldTool.transform.rotation;

                heldTool.transform.SetParent(playerHandTransform);
                heldTool.transform.localPosition = Vector3.zero; // �� ��ġ�� ����
                heldTool.transform.localRotation = prefabRotation;

                held = true;
               
            }
        }
    }

    void TryDropObject()
    {
        if (heldTool != null && held)
        {
            Vector3 dropPosition = transform.position + transform.forward * 2f;
            
            heldTool.transform.SetParent(null); // �տ��� ���� ����
         
            rb.useGravity = true;
            rb.isKinematic = false;

            heldTool.transform.rotation = prefabRotation;
            

            heldTool = null;
            held = false;
        }
    }
}
