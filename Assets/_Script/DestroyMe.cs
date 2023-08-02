using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    [SerializeField]
    private bool UseAnimationTrigger;
    [SerializeField]
    private float DestroyTime = 5.0f;
    private float startTime;

    private bool isAnimationTrigger = false;

    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if (startTime + DestroyTime < Time.time && !UseAnimationTrigger)
            GameObject.Destroy(this.gameObject);

        if(UseAnimationTrigger && isAnimationTrigger)
            GameObject.Destroy(this.gameObject);
    }

    public void AnimationTriggerDestroy()
    {
        isAnimationTrigger = true;
    }
}
