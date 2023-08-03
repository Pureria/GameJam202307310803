using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testscript : MonoBehaviour
{
    [SerializeField] bool gameStart;
    [SerializeField] bool gameClear;
    [SerializeField] bool gameOver;
    [SerializeField] bool gameRestart;

    private void Update()
    {
        if(gameStart)
        {
            gameStart = false;
            GameManager.Instance.GameStart();
        }

        if(gameClear)
        {
            gameClear = false;
            GameManager.Instance.GameClear();
        }

        if(gameOver)
        {
            gameOver = false;
            GameManager.Instance.GameOver();
        }

        if(gameRestart)
        {
            gameRestart = false;
            GameManager.Instance.Restart();
        }
    }
}
