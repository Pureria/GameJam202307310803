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
        // �I�u�W�F�N�g��Viewport���W���擾���܂�
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // �I�u�W�F�N�g����ʊO�ɏo�����ǂ����𔻒肵�܂�
        bool isOutsideViewport = viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1;

        if (isOutsideViewport)
        {
            // �I�u�W�F�N�g���폜���܂�
            Destroy(gameObject);
        }
    }
}
