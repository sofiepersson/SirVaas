using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteAlways]
public class AspectRatioFitter : MonoBehaviour
{
    [SerializeField] private GameField _gameField;
    void Update()
    {
        Debug.Assert(_gameField.height == _gameField.width, "Error: Aspect Ratio Fitter only supports Square GameFields right now.");
        Camera camera = GetComponent<Camera>();
        if (IsInLandscapeMode())
        {
            camera.orthographicSize = _gameField.HalfHeight;
        }
        else
        {
            camera.orthographicSize = _gameField.HalfWidth * Screen.height / Screen.width;
        }
    }

    bool IsInLandscapeMode() => Screen.width >= Screen.height;
}

