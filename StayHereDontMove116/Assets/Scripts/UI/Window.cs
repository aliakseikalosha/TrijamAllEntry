using UnityEngine;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    protected virtual void Awake()
    {
        Hide();
    }
    public virtual void Show()
    {
        canvas.enabled = true;
    }

    public virtual void Hide()
    {
        canvas.enabled = false;
    }
}

