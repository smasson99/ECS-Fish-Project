using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class FishMovementsSystem : ComponentSystem
{
    private struct Filter
    {
        public Transform Transform;
        public FishGameLimits FishGameLimits;
        public FishTranslator FishTranslator;
        public Rigidbody Rigidbody;
    }
    
    protected override void OnUpdate()
    {
        foreach (var entity in GetEntities<Filter>())
        {
            entity.Transform.Translate(entity.Transform.root.forward * entity.FishTranslator.speed * Time.deltaTime, 
                Space.World);
            
            entity.Transform.position =
                MathPositionUtils.GetInRangePosition(entity.Transform.position, entity.FishGameLimits.limits);
        }
    }
}