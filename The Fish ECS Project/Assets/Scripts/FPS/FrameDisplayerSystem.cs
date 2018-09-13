using Unity.Entities;
using UnityEngine;

namespace FPS
{
    public class FrameDisplayerSystem : ComponentSystem
    {
        private struct Filter
        {
            public FrameDisplayer FrameDisplayer;
        }
        
        protected override void OnUpdate()
        {
            foreach (Filter entity in GetEntities<Filter>())
            {
                entity.FrameDisplayer.frameText.text = 
                    FrameDisplayer.FRAME_TEXT + ((int)(1.0f / Time.deltaTime)).ToString();
            }
        }
    }
}