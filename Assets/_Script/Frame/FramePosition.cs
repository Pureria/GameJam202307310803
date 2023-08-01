using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramePosition : MonoBehaviour
{
    public static float LeftPosition = 0.0f;
    public static float RightPosition = 0.0f;
    public static float TopPosition = 0.0f;
    public static float BottomPosition = 0.0f;

    private void Start()
    {
        SetPosition();
    }

    private void Update()
    {
        //������
        //�傫�����ύX���ꂽ�Ƃ��ȂǂɌĂяo���悤�ɂ���
        SetPosition();
    }

    private void SetPosition()
    {
        LeftPosition = transform.position.x - (transform.localScale.x * 0.5f);
        RightPosition = transform.position.x + (transform.localScale.x * 0.5f);
        TopPosition = transform.position.y + (transform.localScale.y * 0.5f);
        BottomPosition = transform.position.y - (transform.localScale.y * 0.5f);
    }

    public float GetLeftPosition() { return LeftPosition; }

    public float GetRightPosition() { return RightPosition; }

    public float GetTopPosition() { return TopPosition; }

    public float GetBottomPosition() { return BottomPosition; }
}
