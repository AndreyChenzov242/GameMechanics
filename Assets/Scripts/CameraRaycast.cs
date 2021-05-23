using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;

    [SerializeField] private float _rayDistance = 2f;

    void FixedUpdate()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _rayDistance, _layerMask))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            if (hit.collider.isTrigger & Input.GetKeyDown(KeyCode.Mouse0))
            {
                //hit.collider.transform.Rotate(0, 0, -120f);
            }
        }
        else
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    }
}
