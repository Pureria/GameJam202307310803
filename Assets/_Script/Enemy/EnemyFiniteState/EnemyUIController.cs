using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIController : MonoBehaviour
{
    private Slider enemyHP;

    private void Start()
    {
        enemyHP = GetComponentInChildren<Slider>();
    }

    public void Initialize(float maxHP)
    {
        enemyHP.maxValue = maxHP;
        enemyHP.minValue = 0.0f;
        enemyHP.value = maxHP;
    }

    public void UpdateHPSlider(float nowHP)
    {
        enemyHP.value = nowHP;
    }
}
