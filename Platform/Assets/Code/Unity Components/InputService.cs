using Leopotam.Ecs.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : MonoBehaviour, IInputService
{
    public bool GetOffset(out Int2 offset)
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        offset = new Int2(0, 0);
        if (x < 0)
        {
            offset.Set(-1, offset.Y);
        }
        if (y < 0)
        {
            offset.Set(offset.X, -1);
        }
        if (x > 0)
        {
            offset.Set(1, offset.Y);
        }
        if (y > 0)
        {
            offset.Set(offset.X, 1);
        }
        //Debug.Log($"H: {Input.GetAxis("Horizontal")} ({offset.X}), V: {Input.GetAxis("Vertical")} ({offset.Y})");

        return offset.X != 0 || offset.Y != 0;
    }
}
