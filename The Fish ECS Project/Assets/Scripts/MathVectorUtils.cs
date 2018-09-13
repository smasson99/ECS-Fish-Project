using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathVectorUtils
{
    public static float GetRotationDirrection(Vector3 currentPosition, Vector3 targetPosition, Transform currentTransform)
    {
        Vector3 pointerVector3 = targetPosition - currentPosition;

        float dotProduct = Vector3.Dot(pointerVector3, currentTransform.root.right);

        if (dotProduct > 0.5f)
        {
            return dotProduct;
        }
        else if (dotProduct < -0.5f)
        {
            return dotProduct;
        }
        
        return 0.0f;
    }
}