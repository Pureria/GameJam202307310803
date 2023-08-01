using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIController : MonoBehaviour
{
    [SerializeField]
    private Slider enemyHP;
    [SerializeField]
    private Slider enemyHPFade;

    [SerializeField]
    private float fadeSpeed = 0.2f;
    [SerializeField]
    private float fadeStartTime = 0.2f;

    private void Awake()
    {
        //enemyHP = GetComponentInChildren<Slider>();
    }

    public void Initialize(float maxHP)
    {
        enemyHP.maxValue = maxHP;
        enemyHP.minValue = 0.0f;
        enemyHP.value = maxHP;

        enemyHPFade.maxValue = maxHP;
        enemyHPFade.minValue = 0.0f;
        enemyHPFade.value = maxHP;
    }

    public void UpdateHPSlider(float nowHP,float lastDamageTime)
    {
        enemyHP.value = nowHP;

        if(enemyHPFade.value - fadeSpeed > nowHP && lastDamageTime + fadeStartTime < Time.time)
            enemyHPFade.value -= fadeSpeed;
    }
}
