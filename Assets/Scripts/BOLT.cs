using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BOLT : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _range = 5f;

    public delegate void UntwistDelegate(GameObject gameObject, bool isUntwisted);
    public static event UntwistDelegate Untwist;


    private void OnMouseDrag()
    {
        if ((_mainCamera.transform.position - transform.position).magnitude > _range)
        {
            return;
        }

        transform.DOLocalMoveZ(2f, 1f);
        transform.DORotate(new Vector3(0, 180, 0), 1f);
        transform.DOScale(Vector3.zero, 0.5f).SetDelay(1f);

        Untwist(gameObject, true);
    }
}
