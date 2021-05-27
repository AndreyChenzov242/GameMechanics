using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Outline outline;

    [SerializeField] protected Camera _mainCamera;
    [SerializeField] protected float _range = 5f;

    private void Awake()
    {
        outline = gameObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.green;
        outline.OutlineWidth = 10f;

        outline.enabled = false;
    }

    private void OnMouseOver()
    {
        if ((_mainCamera.transform.position - transform.position).magnitude > _range)
        {
            outline.enabled = false;
            return;
        }

        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }

    public void ChangeOutlineColor(Color color)
    {
        outline.OutlineColor = color;
    }

    public void ChangeOutlineWidth(float width)
    {
        outline.OutlineWidth = width;
    }
}
