using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pikachu : MonoBehaviour
{
    [SerializeField] private GameField _gameField;

    private void Start()
    {
        Respawn();
    }

    public void OnEaten()
    {
        Respawn();
    }

    private void Respawn()
    {
        Vector3 newPosition = Vector3.zero;
        newPosition.x = Random.Range(0, _gameField.width) - _gameField.HalfWidth + .5f;
        newPosition.y = Random.Range(0, _gameField.height) - _gameField.HalfHeight + .5f;
        newPosition.z = -1;
        transform.position = newPosition;
    }
}