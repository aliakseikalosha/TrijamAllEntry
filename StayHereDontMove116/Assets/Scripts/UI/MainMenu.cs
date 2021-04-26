using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Window
{
    [SerializeField] private Button newGame;
    [SerializeField] private Button quit;
    [SerializeField] private string firstLevelName;
    protected override void Awake()
    {
        Show();
        newGame.onClick.AddListener(StartNewGame);
        quit.onClick.AddListener(Application.Quit);
    }

    private void StartNewGame()
    {
        SceneManager.LoadScene(firstLevelName);
    }
}

