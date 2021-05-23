using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private float _range = 5f;

    public void OnMouseDown()
    {
        if ((_mainCamera.transform.position - transform.position).magnitude > _range)
        {
            return;
        }

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
