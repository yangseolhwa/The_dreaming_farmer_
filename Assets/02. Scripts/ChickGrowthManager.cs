using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickGrowthManager : MonoBehaviour
{
    //public GameObject eggPrefab;
    public GameObject chickPrefab;
    public GameObject chickenPrefab;
    public GameObject chickSpawnPosition;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found.");
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.transform.CompareTag("Incubator"))
                {
                    HatchChick();
                }

                else if(hit.transform.tag == "Chick")
                {
                    ApplyChickFeed(hit.transform.gameObject);
                }
            }
        }
    }

    private void HatchChick()
    {
        PlayerInteractionManager playerInteraction = PlayerInteractionManager.Instance;
        if (playerInteraction == null) return;

        if(playerInteraction.heldTool.name == "Egg(Clone)")
        {
            Destroy(playerInteraction.heldTool.gameObject);
            playerInteraction.heldTool = null;
            playerInteraction.held = false;
            GameObject newChick = Instantiate(chickPrefab, chickSpawnPosition.transform.position, Quaternion.identity);
            StartCoroutine(ConvertToChicken(newChick, 10f));
        }

        else
        {
            Debug.Log("If you grab the egg and click it, it can hatch.");
        }
    }

    private IEnumerator ConvertToChicken(GameObject chickObject, float delay)
    {
        yield return new WaitForSeconds(delay);

        if(chickObject != null)
        {
            Vector3 chickPosition = chickObject.transform.position;
            Destroy(chickObject);
            Instantiate(chickenPrefab, chickPosition, Quaternion.identity);
            Debug.Log("The chick grew into a chicken.");
        }
    }

    private void ApplyChickFeed(GameObject chickObject)
    {
        PlayerInteractionManager playerInteraction = PlayerInteractionManager.Instance;
        if (playerInteraction.heldTool == null || playerInteraction.heldTool.name != "ChickFeed") return;

        StartCoroutine(AccelerateGrowth(chickObject, 0.5f));
        Debug.Log("It has been shortened in growth time.");
    }

    private IEnumerator AccelerateGrowth(GameObject chickObject, float delay)
    {
        yield return new WaitForSeconds(delay);

        if(chickObject != null)
        {
            Vector3 chickPosition = chickObject.transform.position;
            Destroy(chickObject);
            Instantiate(chickenPrefab, chickPosition, Quaternion.identity) ;
            Debug.Log("The chick grew into a chicken.");
        }
    }
}
