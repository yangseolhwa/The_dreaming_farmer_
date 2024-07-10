using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollectionManager : MonoBehaviour
{
    private bool isClicked = false;

    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        if (!isClicked)
        {
            StartCoroutine(ClickFish());
        }
    }

    private IEnumerator ClickFish()
    {
        isClicked = true;

        InventoryManager.Instance.AddItem("Fish");

        Destroy(gameObject);

        yield return null;
    }
}
