using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Screw : Interactable
{
    public delegate void UnscrewDelegate(GameObject gameObject, bool isUntwisted);
    public static event UnscrewDelegate Unscrew;

    private bool _isUsable = true;
    private bool _isUnscrew;

    private void Start()
    {
        SlidePanel.Open += Open;
    }

    private void Open (bool open)
    {
        _isUsable = !open;

        if (!_isUsable)
        {
            ChangeOutlineColor(Color.red);
        }
        else ChangeOutlineColor(Color.green);
    }

    private void OnMouseDown()
    {
        if (!_isUsable)
            return;

        if ((_mainCamera.transform.position - transform.position).magnitude > _range)
        {
            return;
        }

        if (!_isUnscrew)
        {
            transform.DOLocalMoveZ(4f, 1f);
            transform.DORotate(new Vector3(0, 180, 0), 1f);

            Unscrew(gameObject, true);
            _isUnscrew = true;
        }
        else
        {
            transform.DOLocalMoveZ(1.095f, 1f);
            transform.DORotate(new Vector3(90, 0, -180), 1f);

            Unscrew(gameObject, false);
            _isUnscrew = false;
        }
    }
}
