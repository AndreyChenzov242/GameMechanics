using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonPress : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _range = 5f;

    public delegate void PressDelegate(GameObject gameObject, bool isPressed);
    public static event PressDelegate Press;

    private bool isPressed;

    private void OnMouseDown()
    {
        if (!isPressed)
        {
            if ((_mainCamera.transform.position - transform.position).magnitude > _range)
            {
                return;
            }

            transform.DOLocalMoveX(-6.3f, 0.25f);

            Press(gameObject, true);

            isPressed = true;
        }
        
    }
}
