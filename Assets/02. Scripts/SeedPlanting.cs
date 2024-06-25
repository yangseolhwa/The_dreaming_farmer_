using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{
    public GameObject seedPrefab;
    public GameObject carrotPrefab;

    private Camera mainCamera;

    // 각 토양 큐브 별로 씨앗 심었는지 여부를 관리하는 맵
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

        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
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

        // 특정 토양 큐브에 대한 isSeedPlanted 상태 가져오기
        bool isSeedPlanted = GetIsSeedPlanted(soilCube);

        switch (heldToolName)
        {
            case "Seed":

                if (isSeedPlantedMap.ContainsKey(soilCube) && isSeedPlantedMap[soilCube])
                {
                    Debug.Log("이미 씨앗이 심어진 땅입니다.");
                    return;
                }

                if (IsFertile(soilCube) && !isSeedPlanted)
                {
                    GameObject newSeed = Instantiate(seedPrefab, soilCube.transform.position + Vector3.up * 0.5f, Quaternion.identity);
                    SetIsSeedPlanted(soilCube, true);
                    Debug.Log("Seed planted.");

                    StartCoroutine(ConvertToCarrot(newSeed, 3f)); // 3초 후에 당근으로 변경
                }
                else
                {
                    Debug.Log("비옥한 땅을 만든 뒤 심으세요.");
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
            // 초기값은 false로 설정
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
            // 비옥한 땅 여부를 렌더러의 머터리얼을 통해 확인
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
            // 기존 씨앗 제거
            Destroy(seed);

            // 당근 생성
            Instantiate(carrotPrefab, seed.transform.position, Quaternion.identity);
            Debug.Log("Seed converted to Carrot.");
        }
    }
}
