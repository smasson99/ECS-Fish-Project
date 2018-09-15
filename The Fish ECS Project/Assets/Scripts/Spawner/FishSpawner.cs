using Unity.Entities;
using UnityEngine;

namespace Spawner
{
  public class FishSpawner : MonoBehaviour
  {
    [Tooltip("The number of fishes to spawn.")]
    [SerializeField]
    private int numberOfFishes = 100;

    public int NumberOfFishes
    {
      get => numberOfFishes;
      private set => numberOfFishes = value;
    }

    [Tooltip("The fish prefab to spawn X times where X is the number of spawns to do.")]
    [SerializeField]
    private GameObject fishesPrefab = null;

    public GameObject FishesPrefab
    {
      get => fishesPrefab;
      private set => fishesPrefab = value;
    }
  }
}