using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewScene : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex + 1 == 6 ? 0 : SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
