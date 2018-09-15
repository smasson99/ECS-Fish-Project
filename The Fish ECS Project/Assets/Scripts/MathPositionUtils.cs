using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathPositionUtils
{
  /// <summary>
  /// Function wich returns a position in range of 3D limits.
  /// </summary>
  /// <param name="currentPosition">The current position wich is 
  /// potentialy out of the 3D limits.</param>
  /// <param name="limits">Vector3 that contains the 3D limits 
  /// for each axis.</param>
  /// <returns> Vector3 wich represent a position in the limit 3D range.</returns>
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

  /// <summary>
  /// Function wich returns if a position is out 
  /// of limits (true) or not (false)
  /// </summary>
  /// <param name="currentPosition"></param>
  /// <param name="limits"></param>
  /// <returns>Boolean that indicates "true" for a 
  /// position in limit's range or "false" if out of range
  /// .</returns>
  public static bool IsOutOfLimits(Vector3 currentPosition, Vector3 limits)
  {
    return currentPosition.x >= limits.x ||
           currentPosition.x <= -limits.x ||
           currentPosition.y >= limits.y ||
           currentPosition.y <= -limits.y ||
           currentPosition.z >= limits.z ||
           currentPosition.z <= -limits.z;
  }

  /// <summary>
  /// Function that determines if a position is near of a 3D box limits.
  /// </summary>
  /// <param name="currentPosition">Vector3 that represents the 3D position to verify.</param>
  /// <param name="limits">Vector3 that represents the 3D limits for each axis.</param>
  /// <param name="nearDistance">Float that represents the distance that must be 
  /// between the position and one of the limit's axis in order to return true.</param>
  /// <returns>Boolean that indicates "true" if the position is near a 3D limit 
  /// axis and "false" if not.</returns>
  public static bool IsNearLimits(Vector3 currentPosition, Vector3 limits, float nearDistance)
  {
    return -limits.x + nearDistance >= currentPosition.x ||
           limits.x - nearDistance <= currentPosition.x ||
           -limits.y + nearDistance >= currentPosition.y ||
           limits.y - nearDistance <= currentPosition.y ||
           -limits.z + nearDistance >= currentPosition.z ||
           limits.z - nearDistance <= currentPosition.z;
  }

  /// <summary>
  /// Function that generates a 3D world point in a 3D limit, the point won't be the current position.
  /// </summary>
  /// <param name="currentPosition">Vector3 wich represents the current position, that will be ignored 
  /// if generated.</param>
  /// <param name="limits">Vector3 wich represents the max position to be generated.</param>
  /// <returns></returns>
  public static Vector3 Generate3DPointInLimits(Vector3 currentPosition, Vector3 limits)
  {
    Vector3 randomPoint = new Vector3(Random.Range(-limits.x, limits.x),
        Random.Range(-limits.y, limits.y),
        Random.Range(-limits.z, limits.z));

    while (randomPoint == currentPosition)
    {
      randomPoint = new Vector3(Random.Range(-limits.x, limits.x),
          Random.Range(-limits.y, limits.y),
          Random.Range(-limits.z, limits.z));
    }

    return randomPoint;
  }

  /// <summary>
  /// Function wich retruns "true" if a position is near another 
  /// position, depending of a radius.
  /// </summary>
  /// <param name="currentPosition">Vector3 that represents the first position.</param>
  /// <param name="targetPosition">Vector3 that represents the second position.</param>
  /// <param name="radius">Float that represents the radius arround the sedond position that will determine if the fist position is near the second second position.</param>
  /// <returns></returns>
  public static bool IsNearTarget(Vector3 currentPosition, Vector3 targetPosition, float radius)
  {
    Vector3 distanceVector3 = targetPosition - currentPosition;
    return distanceVector3.magnitude <= radius;
  }
}