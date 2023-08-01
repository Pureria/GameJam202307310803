using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag != "Player") return;

        PlayerController pc = collision.transform.root.GetComponent<PlayerController>();
        Damage eDamage = null;
        eDamage = GameManager.Instance.Enemy.GetComponentInChildren<Core>().GetCoreComponent(eDamage);

        eDamage?.AddDamage(pc.GetPlayerData().AttackDamage);
    }
}
