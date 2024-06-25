using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction Instance {  get; private set; }

    public GameObject heldTool; // 손에 잡힌 도구
    public Transform playerHandTransform; // 플레이어 손 위치

    private bool held = false;

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
            TryPickUpTool();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            TryDropTool();
        }
    }

    void TryPickUpTool()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            GameObject hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("Tool") && !held)
            {

                heldTool = hitObject;
                // 도구를 플레이어 손에 잡힌 도구로 설정

                rb = heldTool.GetComponent<Rigidbody>();
                
                rb.useGravity = false;
                rb.isKinematic = true;

                prefabRotation = heldTool.transform.rotation;

                heldTool.transform.SetParent(playerHandTransform);
                heldTool.transform.localPosition = Vector3.zero; // 손 위치에 고정
                heldTool.transform.localRotation = prefabRotation;

                held = true;
               
            }
        }
    }

    void TryDropTool()
    {
        if (heldTool != null && held)
        {
            Vector3 dropPosition = transform.position + transform.forward * 2f;
            
            heldTool.transform.SetParent(null); // 손에서 도구 제거
         
            rb.useGravity = true;
            rb.isKinematic = false;

            heldTool.transform.rotation = prefabRotation;
            

            heldTool = null;
            held = false;
        }
    }
}
