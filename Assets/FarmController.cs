using UnityEngine;

public class FarmSoil : MonoBehaviour
{
    private void Start()
    {
        // Farm Soil의 자식들을 순회하며 스크립트 추가
        foreach (Transform child in transform)
        {
            var cube = child.gameObject;
            cube.AddComponent<FarmTileController>(); // FarmTile 스크립트 추가
        }
    }
}
