using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelOpen : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameObjects;

    private Dictionary<GameObject, bool> _gameObjectsDictionary;

    private bool _isAllBultsUntwisted;

    private void Start()
    {
        _gameObjectsDictionary = new Dictionary<GameObject, bool>();

        foreach (GameObject gameObject in _gameObjects)
        {
            _gameObjectsDictionary.Add(gameObject, false);
        }
    }

    private void OnMouseDrag()
    {
        foreach (KeyValuePair<GameObject, bool> gameObject in _gameObjectsDictionary)
        {
            if (!gameObject.Value)
            {
                _isAllBultsUntwisted = false;
                break;
            }

            _isAllBultsUntwisted = true;
        }

        if (_isAllBultsUntwisted)
        {
            transform.DOLocalMoveZ(4f, 1f);
            transform.DOScale(Vector3.zero, 0.25f).SetDelay(1f);
        }
    }

    public void UntwistBolt(GameObject gameObject)
    {
        if (_gameObjectsDictionary.ContainsKey(gameObject))
        {
            _gameObjectsDictionary[gameObject] = true;
        }
    }
}
