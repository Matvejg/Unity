using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectView: MonoBehaviour, IView
{
    public void UpdatePosition(int x, int y)
    {
        transform.DOKill();
        transform.DOMove(new Vector3(x, y), GameOptions.PlayerMoveSpeed)
            //.SetSpeedBased(true)
            .SetEase(Ease.OutSine);
    }
}
