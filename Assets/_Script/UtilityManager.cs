using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityManager
{
    public static float Animation(float startTime, float endTime, float startKey, float endKey, float nowTime)
    {
        float t = (endTime - startTime);
        float p = (nowTime - startTime) / t;

        float k = (endKey - startKey);
        float key = startKey + (k * p);

        return key;
    }
}
