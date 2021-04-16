using Leopotam.Ecs.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Demo
{
    public class InputService : MonoBehaviour, IInputService
    {
        bool _isLeft = false;
        bool _isRight = false;
        bool _isForward = false;
        bool _isBackward = false;


        void UpdateKeys()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _isLeft = true;
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                _isLeft = false;
            }
        }

        public bool GetOffset(out Int3 offset)
        {
            UpdateKeys();

            int x = 0;
            int y = 0;
            int z = 0;
            if (_isLeft)
            {
                x = x - 1;
            }

            offset = new Int3(x, y, z);
            return offset != Int3.Zero;
        }
    }
}
