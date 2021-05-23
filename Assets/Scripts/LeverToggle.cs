using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverToggle : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _range = 5f;

    public delegate void LeverDownDelegate(GameObject gameObject, bool isDown);
    public static event LeverDownDelegate LeverDown;

    private void OnMouseDrag()
    {
        if (transform.eulerAngles.z != 240f)
        {
            if ((_mainCamera.transform.position - transform.position).magnitude > _range)
            {
                return;
            }
            Vector3 newUp = GetWorldCursorPosition() - transform.position;
            newUp.z = 0;
            transform.up = newUp.normalized;

            if (transform.eulerAngles.z > 340f || transform.eulerAngles.z < 120f)
            {
                transform.eulerAngles = new Vector3(0, 0, 340f);
            }
            if (transform.eulerAngles.z < 240f)
            {
                transform.eulerAngles = new Vector3(0, 0, 240f);
                LeverDown(gameObject, true);
            }
        }
        
    }

    private Vector3 GetWorldCursorPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = _mainCamera.WorldToScreenPoint(transform.position).z;
        return _mainCamera.ScreenToWorldPoint(mousePoint);
    }
}
