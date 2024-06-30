using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawnManager : MonoBehaviour
{
    public GameObject EggPrefab;

    private void Start()
    {
        StartCoroutine(SpawnEgg());
    }

    private IEnumerator SpawnEgg()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(10f, 30f));
            Instantiate(EggPrefab, transform.position, Quaternion.identity);
        }
    }
}
