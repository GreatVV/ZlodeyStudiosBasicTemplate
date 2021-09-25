using System.Collections;
using Leopotam.Ecs;
using LeopotamGroup.Globals;
using UnityEngine;

namespace Zlodey
{
    public sealed class Game : MonoBehaviour
    {
        EcsWorld _world;
        EcsSystems _systems;

        public SceneData SceneData;
        public RuntimeData RuntimeData;
        public StaticData StaticData;

        IEnumerator Start()
        {
            // void can be switched to IEnumerator for support coroutines.

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            RuntimeData = new RuntimeData();
            Service<SceneData>.Set(SceneData);
            Service<RuntimeData>.Set(RuntimeData);
            Service<StaticData>.Set(StaticData);
            Service<EcsWorld>.Set(_world);
            GameInitialization.FullInit();

            _systems
                // register your systems here, for example:
                .Add(new InitializeSystem())
                .Add(new ChangeStateSystem())
                .Add(new StartGameSystem())
                
                //test systems
                //remove in real project
                .Add(new ExampleGameSystem())

                // inject 
                .Inject(SceneData)
                .Inject(RuntimeData)
                .Inject(StaticData)
                .Inject(Service<UI.UI>.Get())

                .Init();
            yield return null;
        }

        void Update()
        {
            _systems?.Run();
        }

        void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}