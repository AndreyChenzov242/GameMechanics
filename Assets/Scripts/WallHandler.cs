using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallHandler : MonoBehaviour
{
    [SerializeField] private float _time = 1f;
    [SerializeField] private float _endPoint = -5f;
    [SerializeField] private GameObject[] _gameObjectsOrder;
    private GameObject[] _gameObjectsCurrentOrder;

    private Dictionary<GameObject, bool> _gameObjectsDictionary;
    private bool _isAllObjectsUsed;


    public void StartDown()
    {
        LeanTween.moveY(gameObject, _endPoint - 0.2f, _time);
    }

    private void Start()
    {
        _gameObjectsCurrentOrder = new GameObject[_gameObjectsOrder.Length];

        _gameObjectsDictionary = new Dictionary<GameObject, bool>();

        foreach (GameObject gameObject in _gameObjectsOrder)
        {
            _gameObjectsDictionary.Add(gameObject, false);
        }

        ButtonPress.Press += Use;
        LeverToggle.LeverDown += Use;
    }

    public void Use(GameObject gameObject, bool isPressed)
    {
        if (_gameObjectsDictionary.ContainsKey(gameObject))
        {
            _gameObjectsDictionary[gameObject] = isPressed;
        }

        for (int i = 0; i < _gameObjectsOrder.Length; i++)
        {
            if(!_gameObjectsCurrentOrder[i])
            {
                _gameObjectsCurrentOrder[i] = gameObject;
                break;
            }
        }

        WallDown();
    }

    private void WallDown()
    {
        foreach (KeyValuePair<GameObject, bool> gameObject in _gameObjectsDictionary)
        {
            if (!gameObject.Value)
            {
                _isAllObjectsUsed = false;
                break;
            }

            _isAllObjectsUsed = true;
        }

        if (_isAllObjectsUsed & Enumerable.SequenceEqual(_gameObjectsOrder, _gameObjectsCurrentOrder))
        {
            StartDown();
        }
    }
}
