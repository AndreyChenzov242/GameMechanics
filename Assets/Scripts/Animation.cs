using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Animation : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _startButton;
    [SerializeField] private Ease _animEase;
    [SerializeField] private Ease _cubeEase;
    [SerializeField] private GameObject _backButton;

    private Sequence sequence;

    private bool _isPaused;

    private void Start()
    {
        _backButton.transform.DOScale(Vector2.zero, 0f);
    }

    public void StartAnimation()
    {
        _startButton.transform.DOMoveY(-Screen.height / 2f, 1f).SetEase(_animEase);
        _camera.transform.DOMove(new Vector3(0, 1.3f, -5f),  3f).SetDelay(1f);

        if (_isPaused)
        {
            StartCoroutine(TogglePause());
        }
        else
        {
            sequence = DOTween.Sequence();
            sequence
            .Append(transform.DOJump(new Vector3(2f, 0.5f, 0), 3f, 1, 1f, false).SetEase(_cubeEase))
            .SetLoops(-1, LoopType.Yoyo)
            .SetDelay(4f, false);
        }
        
        _backButton.transform.DOScale(Vector2.one, 0.5f).SetDelay(4f);
    }

    public void StopAnimation()
    {
        _backButton.transform.DOScale(Vector2.zero, 0.5f);
        _camera.transform.DOMove(new Vector3(0, 2.2f, -8f), 3f).SetDelay(0.5f);
        _startButton.transform.DOMoveY(Screen.height / 2f, 3.5f).SetEase(_animEase);
        sequence.TogglePause();
        _isPaused = true;
    }

    private IEnumerator TogglePause()
    {
        yield return new WaitForSeconds(4f);
        sequence.TogglePause();
    }
}
