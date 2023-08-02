using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crystal : MonoBehaviour
{
    private CrystalController crystal;

    private bool damageFlash;
    private float damageFlashTime;
    private SpriteRenderer sprite;
    private CrystalData crystalData;

    private void Start()
    {
        if (transform.root.TryGetComponent<CrystalController>(out crystal))
        {
            crystalData = crystal.GetCrystalData();
        }
        else
            Debug.LogError(transform.root.name + "Ç…CrystalControllerÇ™å©Ç¬Ç©ÇËÇ‹ÇπÇÒÅB");

        sprite = GetComponent<SpriteRenderer>();
        damageFlash = false;
        damageFlashTime = 0.0f;
    }
    private void Update()
    {
        if(damageFlash)
        {
            if(damageFlashTime + crystalData.CrystalFrashInterval < Time.time)
            {
                sprite.enabled = !sprite.enabled;
                damageFlashTime = Time.time;
            }

            EnemyController ec;
            if(GameManager.Instance.Enemy.TryGetComponent<EnemyController>(out ec))
            {
                if(!ec.GetNowInvincible())
                {
                    damageFlash = false;
                    sprite.enabled = true;
                }
            }
        }        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "Player" || damageFlash) return;

        PlayerController pc = collision.transform.root.GetComponent<PlayerController>();
        Damage eDamage = null;
        eDamage = GameManager.Instance.Enemy.GetComponentInChildren<Core>().GetCoreComponent(eDamage);

        eDamage?.AddDamage(pc.GetPlayerData().AttackDamage);
        damageFlashTime = Time.time;
        damageFlash = true;
        sprite.enabled = false;
    }
}
