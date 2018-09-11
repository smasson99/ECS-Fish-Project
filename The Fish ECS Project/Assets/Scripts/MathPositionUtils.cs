using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathPositionUtils : MonoBehaviour
{
    public static Vector3 GetInRangePosition(Vector3 currentPosition, Vector3 limits)
    {
        if (IsOutOfLimits(currentPosition, limits))
        {
            return new Vector3(Mathf.Clamp(currentPosition.x, -limits.x, limits.x), 
                Mathf.Clamp(currentPosition.y, -limits.y, limits.y), 
                Mathf.Clamp(currentPosition.z, -limits.z, limits.z));
        }

        return currentPosition;
    }

    public static bool IsOutOfLimits(Vector3 currentPosition, Vector3 limits)
    {
        return currentPosition.x >= limits.x ||
               currentPosition.x <= -limits.x ||
               currentPosition.y >= limits.y ||
               currentPosition.y <= -limits.y ||
               currentPosition.z >= limits.z ||
               currentPosition.z <= -limits.z;
    }
}