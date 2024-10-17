using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownConroller : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent; // aCtion은 무조건 void만 반환해야 아니면 Func
    // public event Action<Vector2> OnLookEvent

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // ?. 없으면 말고 있으면 실행
    }

    // public void CallLookEvent(Vector2 direction)
    // {
    //   OnLookEvent?.Invoke(direction);
    // }

}
