using Unity.Entities;
using UnityEngine;

namespace Spawner
{
    public class FishSpawnerSystem : ComponentSystem
    {
        private static readonly Color[] COLORS = new Color[]
            {Color.blue, Color.cyan, Color.gray, Color.green, Color.red, Color.white, Color.yellow, Color.magenta};
        
        private struct FilterForSpawners
        {
            public FishSpawner FishSpawner;
        }

        private struct FilterForFishes
        {
            public FishColor FishColor;
        }
        
        private int GetRandomColorIndex()
        {
            return Random.Range(0, COLORS.Length);
        }

        protected override void OnStartRunning()
        {
            base.OnStartRunning();

            foreach (FilterForSpawners entity in GetEntities<FilterForSpawners>())
            {
                for (int i = 0; i < entity.FishSpawner.NumberOfFishes; ++i)
                {
                    GameObject.Instantiate(entity.FishSpawner.FishesPrefab);
                }
            }
            foreach (FilterForFishes entity in GetEntities<FilterForFishes>())
            {
                entity.FishColor.FishMesh.material.SetColor("_Color", COLORS[GetRandomColorIndex()]);
            }
        }

        protected override void OnUpdate()
        {
          //rien à faire
        }
    }
}