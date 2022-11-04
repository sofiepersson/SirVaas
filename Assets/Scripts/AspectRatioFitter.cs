using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
[ExecuteAlways]
public class AspectRatioFitter : MonoBehaviour
{
    void Update()
    {
        Camera camera = GetComponent<Camera>();
        if (IsInLandscapeMode())
        {
            camera.orthographicSize = 4.5f;
        }
        else
        {
            camera.orthographicSize = 4.5f * Screen.height / Screen.width;
        }
    }

    bool IsInLandscapeMode() => Screen.width >= Screen.height;
}

