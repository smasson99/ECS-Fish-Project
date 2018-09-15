using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishColor : MonoBehaviour
{
  [Tooltip("The mesh to color.")]
  [SerializeField]
  private SkinnedMeshRenderer fishMesh = null;

  public SkinnedMeshRenderer FishMesh
  {
    get => fishMesh;
    private set => fishMesh = value;
  }
}