using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramePosition : MonoBehaviour
{
    public static float LeftPosition = 0.0f;
    public static float RightPosition = 0.0f;
    public static float TopPosition = 0.0f;
    public static float BottomPosition = 0.0f;

    public static FramePosition Instance;

    public bool isChangedScale { get; private set; }
    private Vector3 currentScale;
    private Vector3 defScale;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            GameObject.Destroy(this.gameObject);
    }
    private void Start()
    {
        defScale = transform.localScale;
        isChangedScale = true;
        SetPosition();
    }

    private void Update()
    {
        SetPosition();

        if(!isChangedScale)
        {
            //TODO::スケール変更処理
        }
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

    public void ChangeScale(float xScale,float yScale)
    {
        isChangedScale = false;
        currentScale = new Vector3(xScale, yScale, 0);
    }

    public void ResetScale()
    {
        isChangedScale = false;
        currentScale = defScale;
    }
}
