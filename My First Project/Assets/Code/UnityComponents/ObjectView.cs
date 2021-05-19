using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Demo
{
    public class ObjectView : MonoBehaviour, IView
    {
        public void UpdatePosition(int x, int y, int z)
        {
            transform.DOKill();
            transform.DOMove(new Vector3(x, y, z), 5.0f)
                //.SetSpeedBased(true)
                .SetEase(Ease.OutSine);
               
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}