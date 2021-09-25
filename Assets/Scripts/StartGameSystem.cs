using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Zlodey
{
    internal class StartGameSystem : IEcsRunSystem
    {
        private RuntimeData _runtimeData;
        private EcsWorld _world;
        
        public void Run()
        {
            if (_runtimeData.GameState == GameState.Before)
            {
                if (EventSystem.current.IsPointerOverGameObject() || EventSystem.current.IsPointerOverGameObject(0))
                {
                    return;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    _world.ChangeState(GameState.Playing);
                }
            }
        }
    }
}