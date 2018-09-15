using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
  [Tooltip("The speed to apply when the object rotates.")]
  [SerializeField]
  private float speed = 2.8f;

  public float Speed
  {
    get => speed;
    private set => speed = value;
  }
}