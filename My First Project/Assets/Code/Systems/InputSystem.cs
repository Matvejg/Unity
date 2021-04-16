using Leopotam.Ecs;

namespace Demo
{
    sealed class InputSystem : IEcsRunSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly IInputService _input = default;

        void IEcsRunSystem.Run()
        {
            if (_input.GetOffset(out var offset))
            {
                var e = _world.NewEntity();
                e.Get<EcsInput>().Value = offset;
            }
        }
    }
}