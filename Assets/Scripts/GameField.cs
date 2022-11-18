using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameField : MonoBehaviour
{
    public int width;
    public int height;

    public float HalfWidth => width * .5f;
    public float HalfHeight => height * .5f;

    private void Start()
    {
        transform.localScale = new Vector3(width, height, 1f);
    }
}
