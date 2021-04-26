using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorUI : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GeneratorUIElement prefab;
    [SerializeField] private DragableElement dragPrefab;
    [SerializeField] private Transform elementTarget;
    [SerializeField] private Transform sceneTarget;
    [SerializeField] private Button clearAll;
    [SerializeField] private Button generateDescription;
    [SerializeField] private Text description;

    [SerializeField] private List<SpriteData> datas = new List<SpriteData>();
    [SerializeField] private List<DescriptionData> descriptions = new List<DescriptionData>();

    private List<GeneratorUIElement> elements = new List<GeneratorUIElement>();
    private List<DragableElement> dragElements = new List<DragableElement>();
    private List<string> namesOfSpawnedObject = new List<string>();
    private Unity.Mathematics.Random rnd = new Unity.Mathematics.Random();
    private void Awake()
    {
        rnd.InitState((uint)DateTime.Now.Ticks);
        clearAll.onClick.AddListener(ClearScene);
        generateDescription.onClick.AddListener(GenerateDescription);
        foreach (var data in datas)
        {
            var e = Instantiate(prefab, elementTarget);
            e.transform.localScale = Vector3.one;
            e.Init(data);
            e.OnClick += SpawnSprite;
            elements.Add(e);
        }
    }

    private void SpawnSprite(SpriteData data)
    {
        var e = Instantiate(dragPrefab, sceneTarget);
        e.transform.localScale = Vector3.one;
        e.Init(data.sprite, canvas.scaleFactor);
        dragElements.Add(e);
        namesOfSpawnedObject.Add(data.Name);
    }

    private void ClearScene()
    {
        foreach (var e in dragElements)
        {
            Destroy(e.gameObject);
        }
        dragElements.Clear();
        namesOfSpawnedObject.Clear();
    }

    private void GenerateDescription()
    {
        if (namesOfSpawnedObject.Count == 0)
        {

            return;
        }
        var data = descriptions[rnd.NextInt(descriptions.Count)];
        var words = new string[data.numberOfInsertedWord];
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = namesOfSpawnedObject[rnd.NextInt(namesOfSpawnedObject.Count)];
        }
        description.text = string.Format(data.text.Replace("(L)","\n"), words);
    }

    [Serializable]
    public class DescriptionData
    {
        public int numberOfInsertedWord = 1;
        public string text = "{0} days gone \n you had to save the earth to {0} can live peacfuly";
    }

    [Serializable]
    public class SpriteData
    {
        public string Name;
        public Sprite sprite;
    }
}
