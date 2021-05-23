using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class UntwistBolt : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private OnUntwist OnUntwist;
    [SerializeField] private float _range = 5f;


    private void OnMouseDrag()
    {
        if ((_mainCamera.transform.position - transform.position).magnitude > _range)
        {
            return;
        }

        transform.DOLocalMoveZ(2f, 1f);
        transform.DORotate(new Vector3(0, 180, 0), 1f);
        transform.DOScale(Vector3.zero, 0.5f).SetDelay(1f);

        OnUntwist.Invoke(gameObject);
    }
}

[System.Serializable]
public class OnUntwist : UnityEvent<GameObject> { }
