using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{
    public void GeneratePrefab(GameObject prefab,Vector3 pos)
    {
        Instantiate(prefab, pos, Quaternion.identity);
    }
}
