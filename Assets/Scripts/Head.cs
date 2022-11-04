using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class RotationHandler
{
    public KeyCode input;
    public Vector3 direction;
    public Transform transform;
    
    private bool hasTapped;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            hasTapped = true;
        }
    }
    public void FixedUpdate()
    {
        if (Input.GetKey(input) || hasTapped)
        {
            transform.Rotate(direction);
        }

        hasTapped = false;
    }
}

public class Head : MonoBehaviour
{
    public RotationHandler[] rotationHandlers;
    private GameObject someGameObject;

    void Update()
    {
        for (var i = 0; i < rotationHandlers.Length; i++)
        {
            rotationHandlers[i].Update();
        }
    }
    
    void FixedUpdate()
    {
        for (var i = 0; i < rotationHandlers.Length; i++)
        {
            rotationHandlers[i].FixedUpdate();
        }
        transform.position += transform.up;
    }
}
