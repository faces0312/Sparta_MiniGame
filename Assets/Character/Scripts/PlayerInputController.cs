﻿using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownConroller
{
    //private Camera camera;
    //private void Awake()
    //{
    //camera = Camera.main; // mainCamera 태그 붙어있는 카메라를 가져온다.
    //}
    public void Start()
    {
        Debug.Log("굿");
    }

    public void OnMove(InputValue value)
    {
        Debug.Log(value);
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
        // 실제 움직이는 처리는 여기서 하는게 아니라 PlayerMovemen에서 함
    }

    //public void OnLook(InputValue value)
    //{
    //Vector2 newAim = value.Get<Vector2>();
    //Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
    //newAim = (worldPos - (Vector2)transform.position).normalized;

    //CallLookEvent(newAim);
    //}

}


