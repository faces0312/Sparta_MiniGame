using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int speed = 5;
    private PlayerInput input;

    void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    void Update()
    {
        transform.Translate(input.dir * speed * Time.deltaTime, 0, 0);
    }
}
