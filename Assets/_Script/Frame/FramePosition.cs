using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FramePosition : MonoBehaviour
{
    [SerializeField]
    private float ChangeScaleTime = 2.0f;

    [SerializeField]
    private bool isDebugChangeScale;
    [SerializeField]
    private Vector3 debugChangeScale = Vector3.zero;

    public static float LeftPosition = 0.0f;
    public static float RightPosition = 0.0f;
    public static float TopPosition = 0.0f;
    public static float BottomPosition = 0.0f;

    public static FramePosition Instance;

    //フレームのスケール変更処理が終了しているか
    public bool isChangedScale { get; private set; }

    private float nowChangeScaleTime;
    private Vector3 reChangeScale;
    private Vector3 currentScale;
    private Vector3 defScale;
    private Vector3 workspace;
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
            workspace = new Vector3(Animation(0, ChangeScaleTime, reChangeScale.x, currentScale.x, nowChangeScaleTime),
                                    Animation(0, ChangeScaleTime, reChangeScale.y, currentScale.y, nowChangeScaleTime),
                                    0);
            transform.localScale = workspace;
            if(nowChangeScaleTime >= ChangeScaleTime)
            {
                isChangedScale = true;
            }
            nowChangeScaleTime += Time.deltaTime;
        }

        if(isChangedScale && isDebugChangeScale)
        {
            isDebugChangeScale = false;
            ChangeScale(debugChangeScale.x, debugChangeScale.y);
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
        nowChangeScaleTime = 0.0f;
        isChangedScale = false;
        reChangeScale = transform.localScale;
        currentScale = new Vector3(xScale, yScale, 0);
    }

    public void ResetScale()
    {
        nowChangeScaleTime = 0.0f;
        isChangedScale = false;
        reChangeScale = transform.localScale;
        currentScale = defScale;
    }

    public static float Animation(float startTime, float endTime, float startKey, float endKey, float nowTime)
    {
        float t = (endTime - startTime);
        float p = (nowTime - startTime) / t;

        float k = (endKey - startKey);
        float key = startKey + (k * p);

        return key;
    }
}
