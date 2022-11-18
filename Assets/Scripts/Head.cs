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
        if (Input.GetKeyDown(input))
        {
            hasTapped = true;
        }
    }
    public void FixedUpdate()
    {
        Debug.Log($"Input {input} pressed: {Input.GetKey(input)}");
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
    [SerializeField] private GameField _gameField;
    [SerializeField] private Body _bodyPrefab;

    private void Start()
    {
        Vector3 position = Vector3.zero;
        position.x = _gameField.width / 2 - _gameField.HalfWidth + .5f;
        position.y = _gameField.height / 2 - _gameField.HalfHeight + .5f;
        transform.position = position;
    }

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
        Vector3 nextPosition = transform.position + transform.up;
        nextPosition.x = (nextPosition.x + 3 * _gameField.HalfWidth) % _gameField.width - _gameField.HalfWidth;
        nextPosition.y = (nextPosition.y + 3 * _gameField.HalfHeight) % _gameField.height - _gameField.HalfHeight;

        RaycastHit2D hit = Physics2D.BoxCast(nextPosition, Vector2.one * .9f, 0f, Vector2.zero);
        Pikachu pikachu = hit.collider?.GetComponent<Pikachu>();
        if (pikachu == null)
        {
            // no pikachu eaten, move body
        }
        else
        {
            Body newBody = Instantiate(_bodyPrefab, transform.position, transform.rotation);
            pikachu.OnEaten();
        }
        
        transform.position = nextPosition;
    }
}
