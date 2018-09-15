using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGameLimits : MonoBehaviour
{
  [Tooltip("The limits of the fish patrol for each axis.")]
  [SerializeField]
  private Vector3 limits = new Vector3(60, 60, 60);

  public Vector3 Limits
  {
    get => limits;
    private set => limits = value;
  }
}