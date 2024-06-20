using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmTileController : MonoBehaviour
{
    public Material untiled;
    public Material tilled;
    public Material fertile;

    private void OnMouseDown()
    {
        // Ŭ���� ť���� ���¸� ����
        var cubeRenderer = GetComponent<Renderer>();
        if (cubeRenderer.material == untiled)
        {
            cubeRenderer.material = tilled;
        }
        else if (cubeRenderer.material == tilled)
        {
            cubeRenderer.material = fertile;
        }
        // �߰� ���� ���� ���� (����� ������ �� �̻� ���� ����)
    }
}
