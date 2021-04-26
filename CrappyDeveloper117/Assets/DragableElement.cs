using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableElement : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Image image;
    private float canvasScale;
    private RectTransform rect;
    private bool selected = false;
    private void Awake()
    {
        rect = image.rectTransform;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        selected = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rect.anchoredPosition += eventData.delta / canvasScale;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        selected = false;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    private void Update()
    {
        if (selected)
        {
            if (Input.GetKey(KeyCode.S))
            {
                rect.localScale *= 1 + Input.mouseScrollDelta.y / 5;
                rect.localScale = Vector3.one * Mathf.Min(Mathf.Max(0.5f, rect.localScale.x), 3);
            }
            if (Input.GetKey(KeyCode.R))
            {
                var rot = rect.rotation.eulerAngles;
                rot.z += Input.mouseScrollDelta.y * 10f;
                rect.rotation = Quaternion.Euler(rot);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                rect.SetSiblingIndex(rect.GetSiblingIndex() + -1);
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                rect.SetSiblingIndex(rect.GetSiblingIndex() + 1);
            }
        }
    }

    internal void Init(Sprite sprite, float canvasScale)
    {
        image.sprite = sprite;
        this.canvasScale = canvasScale;
    }
}