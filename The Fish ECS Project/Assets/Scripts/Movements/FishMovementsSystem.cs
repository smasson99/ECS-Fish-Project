using Unity.Entities;
using UnityEngine;

namespace Movements
{
    public class FishMovementsSystem : ComponentSystem
    {
        private const float NEAR_TARGET_RADIUS_VALUE = 5.5f;
    
        private struct Filter
        {
            public Transform Transform;
            public FishGameLimits FishGameLimits;
            public Translator Translator;
            public Rotator Rotator;
            public FishTargeter FishTargeter;
        }

        protected override void OnStartRunning()
        {
            base.OnStartRunning();
            foreach (var entity in GetEntities<Filter>())
            {
                entity.FishTargeter.targetPosition =
                    MathPositionUtils.
                        Generate3DPointInLimits(entity.Transform.position, entity.FishGameLimits.Limits);
            }
        }

        protected override void OnUpdate()
        {
            foreach (var entity in GetEntities<Filter>())
            {
                entity.Transform.Translate(entity.Transform.root.forward * entity.Translator.Speed * Time.deltaTime, 
                    Space.World);
            
                entity.Transform.position =
                    MathPositionUtils.GetInRangePosition(entity.Transform.position, entity.FishGameLimits.Limits);
            
            
                Quaternion rotationQuaternion = Quaternion.LookRotation(entity.FishTargeter.targetPosition - 
                                                                        entity.Transform.position);
            
                entity.Transform.rotation = Quaternion.Slerp(entity.Transform.rotation, rotationQuaternion,
                    entity.Rotator.Speed * Time.deltaTime);
            
                if (MathPositionUtils.IsNearTarget(entity.Transform.position, entity.FishTargeter.targetPosition,
                        NEAR_TARGET_RADIUS_VALUE) || 
                    MathPositionUtils.IsNearLimits(entity.Transform.position, entity.FishGameLimits.Limits, 5.6f))
                {
                    entity.FishTargeter.targetPosition =
                        MathPositionUtils.
                            Generate3DPointInLimits(entity.Transform.position, entity.FishGameLimits.Limits);
                }
            }
        }
    }
}