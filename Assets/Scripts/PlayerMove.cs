using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 4.0f;

    private CharacterController _controller;
    private Vector3 moveDirection = Vector3.zero;
    private float _rotateX;

    void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (_controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= _playerSpeed;
        }
        moveDirection.y -= 20f * Time.deltaTime;
        _controller.Move(moveDirection * Time.deltaTime );

        _rotateX += Input.GetAxis("Mouse X") * 5f;
        _controller.transform.rotation = Quaternion.Euler(0, _rotateX, 0);
    }
}
