using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenSlider : MonoBehaviour
{
    [SerializeField] private float _time = 1f;
    [SerializeField] private float _startPoint = 5f;
    [SerializeField] private float _endPoint = -5f;

    public void StartDown()
    {
        LeanTween.moveY(gameObject, _endPoint - 0.2f, _time);
    }

    public void StartUp()
    {
        LeanTween.moveY(gameObject, _startPoint, _time);
    }
}
