using System;
using UnityEngine;
using UnityEngine.UI;
using static GeneratorUI;

public class GeneratorUIElement : MonoBehaviour
{
    public Action<SpriteData> OnClick;

    [SerializeField] private Button button;
    [SerializeField] private Text text;
    [SerializeField] private Image image;
    private SpriteData data = null;

    internal void Init(SpriteData data)
    {
        this.data = data;
        image.sprite = data.sprite;
        text.text = data.Name;
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => OnClick?.Invoke(this.data));
    }
}
