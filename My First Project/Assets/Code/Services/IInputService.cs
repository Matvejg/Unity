using Leopotam.Ecs;
using Leopotam.Ecs.Types;

namespace Demo
{
    public interface IInputService
    {
        bool GetOffset(out Int3 offset);
    }
}