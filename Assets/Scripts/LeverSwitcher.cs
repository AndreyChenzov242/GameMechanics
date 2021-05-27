using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverSwitcher : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _range = 5f;

    private float _startPoint = 340f;
    private float _endPoint = 240f;

    public delegate void PercentageDelegate(float percentage);
    public static event PercentageDelegate Percentage;

    private void OnMouseDrag()
    {
        if ((_mainCamera.transform.position - transform.position).magnitude > _range)
        {
            return;
        }
        Vector3 newUp = GetWorldCursorPosition() - transform.position;
        newUp.z = 0;
        transform.up = newUp.normalized;

        if (transform.eulerAngles.z > _startPoint || transform.eulerAngles.z < 120f)
        {
            transform.eulerAngles = new Vector3(0, 0, _startPoint);

        }
        if (transform.eulerAngles.z < _endPoint)
        {
            transform.eulerAngles = new Vector3(0, 0, _endPoint);
        }

        Percentage(Mathf.InverseLerp(_startPoint, _endPoint, transform.eulerAngles.z));
    }

    private Vector3 GetWorldCursorPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = _mainCamera.WorldToScreenPoint(transform.position).z;
        return _mainCamera.ScreenToWorldPoint(mousePoint);
    }
}