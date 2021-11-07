using System;
using Leopotam.Ecs;
using UnityEngine;

namespace Zlodey
{
    class ChangeStateSystem : IEcsRunSystem
    {
        private UI _ui;
        private EcsFilter<ChangeStateEvent> _filter;

        private StaticData _staticData;
        private RuntimeData _runtimeData;
        private SceneData _sceneData;
        private EcsWorld _world;
        
        public void Run()
        {
            foreach (var i in _filter)
            {
                var state = _filter.Get1(i).NewGameState;
                _runtimeData.GameState = state;
                switch (state)
                {
                    case GameState.Before:
                        _ui.MenuScreen.Show(true);
                        _ui.MenuScreen.Level.text = $"Level {_runtimeData.Level + 1}";
                        
                        _ui.GameScreen.Show(false);
                        break;
                    case GameState.Playing:
                        _runtimeData.LevelStartedTime = Time.realtimeSinceStartup;
                        
                        _ui.MenuScreen.Show(false);
                        
                        _ui.GameScreen.Level.text = $"Level {_runtimeData.Level + 1}";
                        _ui.GameScreen.Show(true);
                        break;
                    case GameState.Win:
                        Progress.CurrentLevel++;
                        
                        _ui.GameScreen.Show(false);
                        _ui.WinScreen.Show(true);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                _filter.GetEntity(i).Destroy();
            }
        }
    }
}