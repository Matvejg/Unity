using Leopotam.Ecs;

namespace Demo
{
    sealed class GameInitSystems : IEcsInitSystem
    {
        // auto-injected fields.
        readonly EcsWorld _world = null;
        readonly Rnd _rnd = default;

        ObjectTypeEnum GetObjectType(int index)
        {
            if (index < 40)
            {
                return ObjectTypeEnum.Cube;
            }
            else
            if (index < 70)
            {
                return ObjectTypeEnum.Sphere;
            }
            else
            {
                return ObjectTypeEnum.Capsule;
            }
        }

        public void Init()
        {
           

            for (int i = 0; i < 100; i++)
            {
                var e = _world.NewEntity();
                var x = _rnd.Next(-10, 10);
                var y = _rnd.Next(-10, 10);
                var z = _rnd.Next(-10, 10);
                e.Get<Position>().Value.Set(x, y, z);
                var r = _rnd.NextDouble();
                var g = _rnd.NextDouble();
                var b = _rnd.NextDouble();
                e.Get<Color>().Value.Set((float)r, (float)g, (float)b);
                var type = GetObjectType(_rnd.Next(0, 100));
                e.Get<ObjectType>().Value = type;
             }
        }
    }
}