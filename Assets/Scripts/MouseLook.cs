using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Vector2 _minMaxY = new Vector2(-40f, 40f);
    [SerializeField] private GameObject player;

    private float _moveY;
    private Camera _camera;
    
    void Start()
    {
        _camera = GetComponent<Camera>();
    }
    
    void Update()
    {
        _moveY -= Input.GetAxis("Mouse Y") * 5f;

        _camera.transform.localRotation = Quaternion.Euler(Mathf.Clamp(_moveY, _minMaxY.x, _minMaxY.y), 0, 0);
    }
}
