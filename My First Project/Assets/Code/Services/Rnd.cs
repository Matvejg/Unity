using Leopotam.Ecs;
using Leopotam.Ecs.Types;

namespace Demo
{
    public class Rnd
    {
        System.Random _random;
        public Rnd(int seed)
        {
            _random = new System.Random(seed);
        }

        public Rnd()
        {
            _random = new System.Random();
        }

        public int Next(int minValue, int maxValue)
        {
            return _random.Next(minValue, maxValue);
        }

        public double NextDouble()
        {
            return _random.NextDouble();
        }
    }
}