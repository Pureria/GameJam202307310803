using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject Player { get; private set; }
    public GameObject Enemy { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            GameObject.Destroy(this);
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    #region Set Function
    public void SetPlayer(GameObject player)
    {
        this.Player = player;
    }

    public void SetEnemy(GameObject enemy)
    {
        this.Enemy = enemy;
    }
    #endregion
}
