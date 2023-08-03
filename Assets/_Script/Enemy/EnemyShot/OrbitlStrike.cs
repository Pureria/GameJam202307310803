using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitlStrike : MonoBehaviour
{
    [SerializeField]
    private Color searchColor;
    [SerializeField]
    private Color attackColor;
    [SerializeField]
    private float searchTime;
    [SerializeField]
    private float searchSpeed;
    [SerializeField]
    private float attackTime;
    [SerializeField]
    private EnemyShotMove shotMove;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private GameObject colliderObject;

    private float startTime;
    private bool isSearch;
    private void Start()
    {
        isSearch = true;
        startTime = Time.time;
        sprite.color = searchColor;
        colliderObject.SetActive(false);
    }

    private void Update()
    {
        if(isSearch)
        {
            Vector2 direction = GameManager.Instance.Player.transform.position - transform.position;
            shotMove.SetDirection(direction.normalized, searchSpeed);

            if(startTime + searchTime < Time.time)
            {
                isSearch = false;
                startTime = Time.time;
                sprite.color = attackColor;
                shotMove.SetCanMove(false);
                colliderObject.SetActive(true);
            }
        }
        else
        {
            if(startTime + attackTime < Time.time)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}
