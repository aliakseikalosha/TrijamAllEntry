using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelEnd : Window
{
    [SerializeField] private TMPro.TMP_Text text;
    [SerializeField] private Button ok;
    [SerializeField] private Button mainMenu;
    [SerializeField] private string menuLevel;
    private Action action;
    public void Show(Action action, string message)
    {
        Show();
        Time.timeScale = 0;
        this.action = action;
        text.text = message;
    }

    protected override void Awake()
    {
        base.Awake();
        ok.onClick.AddListener(DoAction);
        mainMenu.onClick.AddListener(GoToMainMenu);
    }

    private void GoToMainMenu()
    {
        SceneManager.LoadScene(menuLevel);
    }

    private void DoAction()
    {
        Time.timeScale = 1;
        action?.Invoke();
    }
}