using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class LeanTweenSlider : MonoBehaviour
{
    [SerializeField] private float _time = 1f;
    [SerializeField] private float _startPoint = 5f;
    [SerializeField] private float _endPoint = -5.2f;

    private void Start()
    {
        LeverSwitcher.Percentage += TransformY;
    }

    public void StartDown()
    {
        LeanTween.moveY(gameObject, _endPoint, _time);
    }

    public void StartUp()
    {
        LeanTween.moveY(gameObject, _startPoint, _time);
    }

    public void TransformY(float percentage)
    {
        LeanTween.moveY(gameObject, Mathf.Lerp(_startPoint, _endPoint, percentage), 0);
    }
}
