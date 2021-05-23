using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewController : MonoBehaviour
{
    [SerializeField] private RectTransform _prefab;
    [SerializeField] private RectTransform _contnent;
    [SerializeField] private Sprite[] _images;

    private Text _text;
    private Image _image;

    private void Start()
    {
        _text = _prefab.Find("Text").GetComponent<Text>();
        _image = _prefab.Find("Image").GetComponent<Image>();
    }


    public void AddItem()
    {
        _text.text = Random.Range(0,999) + "$";
        _image.sprite = _images[Random.Range(0, _images.Length)];

        var instance = Instantiate(_prefab.gameObject) as GameObject;
        instance.transform.SetParent(_contnent, false);
    }

    
}
