using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnExitScreen : MonoBehaviour
{
    private Camera mainCamera;
    [SerializeField]
    private Renderer objectRenderer;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // オブジェクトのViewport座標を取得します
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // オブジェクトが画面外に出たかどうかを判定します
        bool isOutsideViewport = viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1;

        if (isOutsideViewport)
        {
            // オブジェクトを削除します
            Destroy(gameObject);
        }
    }
}
