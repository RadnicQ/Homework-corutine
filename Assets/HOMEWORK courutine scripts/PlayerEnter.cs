using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnter : MonoBehaviour
{
    public event Action Enter;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Enter?.Invoke();
    }
}
