using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action LeftButtonClicked;

    private const int _mouseButtonLeft = 0;

    private void Update()
    {
        if (Input.GetMouseButtonUp(_mouseButtonLeft))
            LeftButtonClicked?.Invoke();
    }
}
