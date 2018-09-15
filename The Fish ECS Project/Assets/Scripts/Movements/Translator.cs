using UnityEngine;

public class Translator : MonoBehaviour
{
  [Tooltip("The speed to apply when the object translates.")]
  [SerializeField]
  private float speed = 2.5f;

  public float Speed
  {
    get => speed;
    private set => speed = value;
  }
}