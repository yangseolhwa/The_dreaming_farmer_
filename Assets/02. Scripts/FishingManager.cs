using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingManager : MonoBehaviour
{

    public GameObject fishPrefab;
    public GameObject fishSpawnPosition;
    public GameObject fishingAreaPoint;
    public Animator rodAnimator;

    private Camera mainCamera;

    private bool baitState = false;

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
        if (mainCamera == null) return;

        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                
                if (hit.transform.name == "Bait")
                {
                    ParticleManager.Instance.PlayParticle(ParticleManager.Instance.baitParticle, hit.transform.position + Vector3.up * 0.7f, 1.0f);
                    baitState = true;
                    Debug.Log($"baitState = {baitState}");
                    
                }

                else if (hit.transform.CompareTag("FishingArea"))
                {
                    ParticleManager.Instance.PlayParticle(ParticleManager.Instance.fishingStartParticle, fishingAreaPoint.transform.position + Vector3.up , 1.0f);
                    StartFishingIfValid();

                }
            }
            else
            {
                Debug.LogWarning("Raycast hit transform is null.");
            }
        }
    }

    private void StartFishingIfValid()
    {
        PlayerInteractionManager playerInteraction = PlayerInteractionManager.Instance;
        
        if(playerInteraction.heldTool == null || playerInteraction.heldTool.name != "Rod" || baitState == false)
        {
            Debug.Log("You can fish using a fishing rod and bait.");
            return;
        }

        else if(playerInteraction.heldTool.name == "Rod" && baitState == true)
        {
            StartCoroutine(Fising(3f));
        }
    }

    private IEnumerator Fising(float delay)
    {

        yield return new WaitForSeconds(delay);

        SoundManager.Instance.PlayFishSplashSFX();

        rodAnimator.SetBool("isFishing", true);
        ParticleManager.Instance.PlayParticle(ParticleManager.Instance.fishingEndParticle, fishingAreaPoint.transform.position + Vector3.up, 3.0f);
        

        yield return new WaitForSeconds(5f);

        rodAnimator.SetBool("isFishing", false);

        Vector3 fishPosition = fishSpawnPosition.transform.position;
        Instantiate(fishPrefab, fishPosition, Quaternion.identity);
        baitState = false;

        Debug.Log("Caught a fish.");
        
    }
}
