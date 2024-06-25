using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{
    public GameObject seedPrefab;
    public GameObject carrotPrefab;

    private Camera mainCamera;

    // �� ��� ť�� ���� ���� �ɾ����� ���θ� �����ϴ� ��
    private Dictionary<GameObject, bool> isSeedPlantedMap;


    private void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found.");
            return;
        }

        isSeedPlantedMap = new Dictionary<GameObject, bool>();
    }

    void Update()
    {
        if (mainCamera == null) return;

        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.CompareTag("FarmSoil"))
                {
                    PlantSeed(hit.transform.gameObject);
                }
            }
        }
    }

    private void PlantSeed(GameObject soilCube)
    {
        PlayerInteraction playerInteraction = PlayerInteraction.Instance;
        SoilManager soilManager = SoilManager.Instance;

        if (playerInteraction.heldTool == null) return;

        string heldToolName = playerInteraction.heldTool.name;

        // Ư�� ��� ť�꿡 ���� isSeedPlanted ���� ��������
        bool isSeedPlanted = GetIsSeedPlanted(soilCube);

        switch (heldToolName)
        {
            case "Seed":

                if (isSeedPlantedMap.ContainsKey(soilCube) && isSeedPlantedMap[soilCube])
                {
                    Debug.Log("�̹� ������ �ɾ��� ���Դϴ�.");
                    return;
                }

                if (IsFertile(soilCube) && !isSeedPlanted)
                {
                    GameObject newSeed = Instantiate(seedPrefab, soilCube.transform.position + Vector3.up * 0.5f, Quaternion.identity);
                    SetIsSeedPlanted(soilCube, true);
                    Debug.Log("Seed planted.");

                    StartCoroutine(ConvertToCarrot(newSeed, 3f)); // 3�� �Ŀ� ������� ����
                }
                else
                {
                    Debug.Log("����� ���� ���� �� ��������.");
                }
                break;

            case "Fertilizer":
                if (isSeedPlanted)
                {
                   
                }
                break;

            default:
                Debug.LogWarning("Unhandled tool: " + heldToolName);
                break;
        }
    }

    private bool GetIsSeedPlanted(GameObject soilCube)
    {
        if (isSeedPlantedMap.ContainsKey(soilCube))
        {
            return isSeedPlantedMap[soilCube];
        }
        else
        {
            // �ʱⰪ�� false�� ����
            isSeedPlantedMap[soilCube] = false;
            return false;
        }
    }

    private void SetIsSeedPlanted(GameObject soilCube, bool value)
    {
        if (isSeedPlantedMap.ContainsKey(soilCube))
        {
            isSeedPlantedMap[soilCube] = value;
        }
        else
        {
            isSeedPlantedMap.Add(soilCube, value);
        }
    }

    private bool IsFertile(GameObject soilCube)
    {
        Renderer renderer = soilCube.GetComponent<Renderer>();
        if (renderer != null)
        {
            // ����� �� ���θ� �������� ���͸����� ���� Ȯ��
            return renderer.material.name.Contains("Fertile");
        }
        else
        {
            Debug.LogWarning($"Renderer not found on {soilCube.name}");
            return false;
        }
    }

    private IEnumerator ConvertToCarrot(GameObject seed, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (seed != null)
        {
            // ���� ���� ����
            Destroy(seed);

            // ��� ����
            Instantiate(carrotPrefab, seed.transform.position, Quaternion.identity);
            Debug.Log("Seed converted to Carrot.");
        }
    }
}
