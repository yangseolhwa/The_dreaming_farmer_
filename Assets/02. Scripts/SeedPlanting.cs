using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{
    public GameObject seedPrefab;
    public GameObject carrotShootPrefab;
    public GameObject carrotPrefab;

    private Camera mainCamera;
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
                else if (hit.transform.tag == "CarrotShoot")
                {
                    ApplyFertilizer(hit.transform.gameObject);
                }
            }
        }
    }

    private void PlantSeed(GameObject soilCube)
    {
        PlayerInteraction playerInteraction = PlayerInteraction.Instance;
        if (playerInteraction.heldTool == null) return;

        if (playerInteraction.heldTool.name == "Seed" && !GetIsSeedPlanted(soilCube) && IsFertile(soilCube))
        {
            GameObject newSeed = Instantiate(seedPrefab, soilCube.transform.position + Vector3.up * 0.5f, Quaternion.identity);
            SetIsSeedPlanted(soilCube, true);
            Debug.Log("Seed planted.");
            StartCoroutine(ConvertToCarrot(newSeed, 3f)); // 3초 후에 당근 순으로 변경
        }
        else
        {
            Debug.Log("Make fertile land and plant it.");
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
            isSeedPlantedMap[soilCube] = false;
            return false;
        }
    }

    private void SetIsSeedPlanted(GameObject soilCube, bool value)
    {
        isSeedPlantedMap[soilCube] = value;
    }

    private bool IsFertile(GameObject soilCube)
    {
        Renderer renderer = soilCube.GetComponent<Renderer>();
        if (renderer != null)
        {
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
            Destroy(seed);
            GameObject carrotShoot = Instantiate(carrotShootPrefab, seed.transform.position, Quaternion.identity);
            Debug.Log("Seed converted to Carrot Shoot.");

            yield return new WaitForSeconds(7f);

            if (carrotShoot != null)
            {
                Vector3 carrotPosition = carrotShoot.transform.position;
                Destroy(carrotShoot);
                Instantiate(carrotPrefab, carrotPosition, Quaternion.identity);
                Debug.Log("Carrot Shoot converted to fully grown Carrot.");
            }
        }
    }

    private void ApplyFertilizer(GameObject carrotShoot)
    {
        PlayerInteraction playerInteraction = PlayerInteraction.Instance;
        if (playerInteraction.heldTool == null || playerInteraction.heldTool.name != "Fertilizer") return;

        StartCoroutine(AccelerateGrowth(carrotShoot, 0.5f));
        Debug.Log("It has been shortened in growth time.");
    }

    private IEnumerator AccelerateGrowth(GameObject carrotShoot, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (carrotShoot != null)
        {
            Vector3 carrotPosition = carrotShoot.transform.position;
            Destroy(carrotShoot);
            Instantiate(carrotPrefab, carrotPosition, Quaternion.identity);
            Debug.Log("Carrot Shoot accelerated to fully grown Carrot.");
        }
    }
}
