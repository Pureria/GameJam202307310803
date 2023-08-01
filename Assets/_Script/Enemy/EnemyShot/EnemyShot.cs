using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        //�v���C���[�̏ꍇ
        if(collision.transform.root.gameObject.tag == "Player")
        {
            Damage pDamage = null;
            pDamage = collision.transform.root.gameObject.GetComponentInChildren<Core>().GetCoreComponent(pDamage);
            pDamage?.AddDamage(1.0f);
            if (pDamage == null)
                Debug.LogError(collision.transform.root.gameObject.name + "��Damage�R���|�[�l���g��������܂���B");
        }
    }
}
