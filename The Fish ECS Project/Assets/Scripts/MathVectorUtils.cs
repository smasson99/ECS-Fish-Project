using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathVectorUtils
{
  /// <summary>
  /// Function wich returns the rotation to do in order to point into a target 3D position.
  /// </summary>
  /// <param name="currentPosition">Vector3 that represents the 3D position of the object to rotate.</param>
  /// <param name="targetPosition">Vector3 that represents the 3D position of the object to point to.</param>
  /// <param name="currentTransform">Transform of the current object to rotate.</param>
  /// <returns>Float wich represents the rotation to do in order to point to the object.</returns>
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