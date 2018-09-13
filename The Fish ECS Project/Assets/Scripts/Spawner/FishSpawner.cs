using Unity.Entities;
using UnityEngine;

namespace Spawner
{
    public class FishSpawner : MonoBehaviour
    {
        [Tooltip("The number of fishes to spawn.")] 
        [SerializeField]
        public int numberOfFishes = 100;

        
        public GameObject fishesPrefab = null;
    }
}