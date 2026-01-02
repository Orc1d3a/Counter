using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action LeftButtonClicked;

    private void Update()
    {
        int mouseButtonLeft = 0;

        if (Input.GetMouseButtonUp(mouseButtonLeft))
            LeftButtonClicked?.Invoke();
    }
}
