using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private int _maxCubeCounter = 50;

    private int _posX;
    private int _posY;
    private int _posZ;
    private int _currentCubeCounter;

    void Start()
    {
        StartCoroutine(InstantiateCube());
    }

    public IEnumerator InstantiateCube()
    {
        while(_currentCubeCounter < _maxCubeCounter)
        {
            _posX = Random.Range(-10, 10);
            _posY = Random.Range(5, 10);
            _posZ = Random.Range(-10, 10);
            Instantiate(_cube, new Vector3(_posX, _posY, _posZ), Quaternion.identity);
            _currentCubeCounter++;
            yield return new WaitForSeconds(0.2f);
        }
        
    }
}
