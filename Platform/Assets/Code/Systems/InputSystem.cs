using Ecs;
using Leopotam.Ecs;
using System.Linq;

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
            e.Replace(new Input
            {
                Offset = offset
            });
        }
    }
}