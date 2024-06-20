using UnityEngine;

public class FarmSoil : MonoBehaviour
{
    private void Start()
    {
        // Farm Soil�� �ڽĵ��� ��ȸ�ϸ� ��ũ��Ʈ �߰�
        foreach (Transform child in transform)
        {
            var cube = child.gameObject;
            cube.AddComponent<FarmTileController>(); // FarmTile ��ũ��Ʈ �߰�
        }
    }
}
