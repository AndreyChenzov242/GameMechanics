using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlidePanel : Interactable
{
    [SerializeField] private GameObject[] _gameObjects;

    private Dictionary<GameObject, bool> _gameObjectsDictionary;
    private bool _isAllScrewUnscrewed;
    private Color _color => _isAllScrewUnscrewed ? Color.green : Color.red;

    public delegate void OpenDelegate(bool isOpen);
    public static event OpenDelegate Open;

    private bool _isOpen;

    private void Start()
    {
        _gameObjectsDictionary = new Dictionary<GameObject, bool>();

        foreach (GameObject gameObject in _gameObjects)
        {
            _gameObjectsDictionary.Add(gameObject, false);
        }

        Screw.Unscrew += Unscrew;

        ChangeOutlineColor(_color);
        ChangeOutlineWidth(20f);
    }

    public void Unscrew(GameObject gameObject, bool isUnscrewed)
    {
        if (_gameObjectsDictionary.ContainsKey(gameObject))
        {
            _gameObjectsDictionary[gameObject] = isUnscrewed;
        }

        _isAllScrewUnscrewed = IsAllScrewUnscrewed();

        if (_isAllScrewUnscrewed)
        {
            ChangeOutlineColor(Color.green);
        }
        else ChangeOutlineColor(Color.red);
    }

    private void OnMouseDown()
    {
        if ((_mainCamera.transform.position - transform.position).magnitude > _range)
        {
            return;
        }
        
        if (_isAllScrewUnscrewed)
        {
            if (!_isOpen)
            {
                transform.DOLocalMoveZ(3f, 1f);
                Open(true);
                _isOpen = true;
            }
            else
            {
                transform.DOLocalMoveZ(1.144f, 1f);
                Open(false);
                _isOpen = false;
            }
        }
    }

    private bool IsAllScrewUnscrewed()
    {
        bool isAllScrewUnscrewed = false;

        foreach (KeyValuePair<GameObject, bool> gameObject in _gameObjectsDictionary)
        {
            if (!gameObject.Value)
            {
                isAllScrewUnscrewed = false;
                break;
            }

            isAllScrewUnscrewed = true;
        }

        return isAllScrewUnscrewed;
    }
}
