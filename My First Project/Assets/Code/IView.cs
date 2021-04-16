using UnityEditor;
using UnityEngine;

namespace Demo
{
    public interface IView
    {
        void UpdatePosition(int x, int y, int z);
    }
}