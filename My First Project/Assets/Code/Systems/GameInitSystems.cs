using Leopotam.Ecs;

namespace Demo
{
    sealed class GameInitSystems : IEcsInitSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;

        public void Init()
        {
            var e = _world.NewEntity();
            e.Get<Position>().Value.Set(0, 0, 0);
        }
    }
}