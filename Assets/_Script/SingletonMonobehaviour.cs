using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonMonoBehaviour : MonoBehaviour
{
    public static SingletonMonoBehaviour Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            GameObject.Destroy(this.gameObject);
    }

    public void hoge() { }
}
