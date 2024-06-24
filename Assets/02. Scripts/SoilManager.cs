using UnityEngine;

public class SoilManager : MonoBehaviour
{
    public Material untiledMaterial;
    public Material tilledMaterial;
    public Material fertileMaterial;

    private Camera mainCamera;

    PlayerInteraction playerInteraction;

    [SerializeField]private string heldToolName;

    void Start()
    {
        // 'Resources/Materials' �������� ���͸����� �ε��մϴ�.
        untiledMaterial = Resources.Load<Material>("Materials/Untiled");
        tilledMaterial = Resources.Load<Material>("Materials/Tilled");
        fertileMaterial = Resources.Load<Material>("Materials/Fertile");

        if (untiledMaterial == null || tilledMaterial == null || fertileMaterial == null)
        {
            Debug.LogError("One or more materials could not be loaded. Please check the paths and file names.");
            return;
        }

        // �±׷� ���� ī�޶� ã���ϴ�.
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

        playerInteraction = FindObjectOfType<PlayerInteraction>();

        // ��� �ڽ� ť���� �ʱ� ���͸����� �����մϴ�.
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

        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log($"Hit: {hit.transform.name}");

                if (hit.transform.IsChildOf(transform)) // FarmSoil ������Ʈ�� �ڽ����� Ȯ��
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

            heldToolName = playerInteraction.heldTool.name;

            switch (heldToolName)
            {
                case "Hoe":

                    if (renderer.material.mainTexture == untiledMaterial.mainTexture)
                    {
                        renderer.material = tilledMaterial;
                        Debug.Log("Material changed to Tilled");
                    }
                    break;

                case "WaterCan":

                    if (renderer.material.mainTexture == tilledMaterial.mainTexture)
                    {
                        renderer.material = fertileMaterial;
                        Debug.Log("Material changed to Fertile");
                    }

                    break;
            }
        }

        else
        {
            Debug.LogWarning($"Renderer not found on clicked cube: {cube.name}");
        }
    }

}

