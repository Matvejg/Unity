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
            if (Input.GetKeyDown(KeyCode.D))
            {
                _isRight = true;
            } 
            else if (Input.GetKeyUp(KeyCode.D))
            {
                _isRight = false;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                _isForward = true;
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                _isForward = false;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                _isBackward = true;
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                _isBackward = false;
            }
        }    

        public bool GetOffset(out Int3 offset)
        {
            UpdateKeys();

            int x = 0;
            int y = 0;
            int z = 0;
            //if (_isLeft)
            //{
            //    x = x - 1;
            //}
            //if (_isRight)
            //{
            //    x = x + 1
            //}
            //if (_isForward)
            //{
            //    z = z + 1 
            //}
            //if (_)
            if (Input.GetKeyDown(KeyCode.A))

            {
                x = x - 1;
            }
            if (Input.GetKeyDown(KeyCode.D))

            {
                x = x + 1;
            }
            if (Input.GetKeyDown(KeyCode.W))

            {
                z = z + 1;
            }
            if (Input.GetKeyDown(KeyCode.S))

            {
                z = z - 1;
            }
            offset = new Int3(x, y, z);
            return offset != Int3.Zero;
        }
    }
}


