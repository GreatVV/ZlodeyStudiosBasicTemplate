using Leopotam.Ecs;
using UnityEngine;

namespace Zlodey
{
    public class ExampleGameSystem : IEcsRunSystem
    {
        private EcsWorld _world;
        private RuntimeData _runtimeData;
        private StaticData _staticData;
        
        public void Run()
        {
            if (_runtimeData.GameState == GameState.Playing)
            {
                if (Time.realtimeSinceStartup - _runtimeData.LevelStartedTime > _staticData.TimeToWinLevel)
                {
                    _world.ChangeState(GameState.Win);
                }
            }
        }
    }
}