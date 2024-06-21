using UnityEngine;

public class SoilController : MonoBehaviour
{
    public Material untiledMaterial;
    public Material tilledMaterial;
    public Material fertileMaterial;

    private Camera mainCamera;

    void Start()
    {
        // 'Resources/Materials' 폴더에서 머터리얼을 로드합니다.
        untiledMaterial = Resources.Load<Material>("Materials/Untiled");
        tilledMaterial = Resources.Load<Material>("Materials/Tilled");
        fertileMaterial = Resources.Load<Material>("Materials/Fertile");

        if (untiledMaterial == null || tilledMaterial == null || fertileMaterial == null)
        {
            Debug.LogError("One or more materials could not be loaded. Please check the paths and file names.");
            return;
        }

        // 태그로 메인 카메라를 찾습니다.
        GameObject cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        if (cameraObject != null)
        {
            mainCamera = cameraObject.GetComponent<Camera>();
        }

        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found. Please ensure there is a camera in the scene tagged as 'MainCamera'.");
            return;
        }

        // 모든 자식 큐브의 초기 머터리얼을 설정합니다.
        foreach (Transform child in transform)
        {
            Renderer renderer = child.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = untiledMaterial;
            }
            else
            {
                Debug.LogWarning($"Renderer not found on {child.name}");
            }
        }
    }

    void Update()
    {
        if (mainCamera == null) return;

        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log($"Hit: {hit.transform.name}");

                if (hit.transform.IsChildOf(transform)) // FarmSoil 오브젝트의 자식인지 확인
                {
                    OnCubeClicked(hit.transform.gameObject);
                }
            }
        }
    }

    private void OnCubeClicked(GameObject cube)
    {
        Renderer renderer = cube.GetComponent<Renderer>();
        if (renderer != null)
        {
            Debug.Log($"Clicked on cube: {cube.name}");

            // 현재 머터리얼의 mainTexture를 비교하여 상태 변경
            if (renderer.material.mainTexture == untiledMaterial.mainTexture)
            {
                renderer.material = tilledMaterial;
                Debug.Log("Material changed to Tilled");
            }
            else if (renderer.material.mainTexture == tilledMaterial.mainTexture)
            {
                renderer.material = fertileMaterial;
                Debug.Log("Material changed to Fertile");
            }
            // Fertile 상태에서는 더 이상 변경하지 않음
            else if (renderer.material.mainTexture == fertileMaterial.mainTexture)
            {
                Debug.Log("Already Fertile, no change needed");
            }
        }
        else
        {
            Debug.LogWarning($"Renderer not found on clicked cube: {cube.name}");
        }
    }

}

