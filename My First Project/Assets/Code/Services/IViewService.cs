using Leopotam.Ecs;
using Leopotam.Ecs.Types;

namespace Demo
{
    public interface IViewService
    {
        IView CreateView(int x, int y, int z, Float3 color, ObjectTypeEnum type);
    }
}