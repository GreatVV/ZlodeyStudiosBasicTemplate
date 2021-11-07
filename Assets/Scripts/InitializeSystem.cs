using Leopotam.Ecs;

namespace Zlodey
{
    class InitializeSystem : IEcsInitSystem
    {
        private UI _ui;
        private EcsWorld _world;
        private RuntimeData _runtimeData;

        public void Init()
        {
            _ui.CloseAll();
            _runtimeData.Level = Progress.CurrentLevel;
            _world.ChangeState(GameState.Before);

            //todo continue intialization logic

        }
    }
}