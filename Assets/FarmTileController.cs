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
        // 클릭한 큐브의 상태를 변경
        var cubeRenderer = GetComponent<Renderer>();
        if (cubeRenderer.material == untiled)
        {
            cubeRenderer.material = tilled;
        }
        else if (cubeRenderer.material == tilled)
        {
            cubeRenderer.material = fertile;
        }
        // 추가 상태 변경 로직 (비옥한 땅에서 더 이상 변경 없음)
    }
}
