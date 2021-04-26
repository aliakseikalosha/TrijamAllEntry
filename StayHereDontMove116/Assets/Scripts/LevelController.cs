using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private SpotlightController[] lights;
    [SerializeField] private Coin[] coins;
    [SerializeField] private bool lastLevel = false;
    [SerializeField] private LevelEnd levelEnd;
    [SerializeField] private string nextLevel;
    [SerializeField] private float deathLevel = -10f;
    private int coinsCollected = 0;

    private void Awake()
    {
        foreach (var light in lights)
        {
            light.OnCoughtPlayer += LevelFaild;
        }
        foreach (var coin in coins)
        {
            coin.OnCollected += CollectedCoin;
        }
    }

    public void Update()
    {

        if (deathLevel > player.position.y)
        {
            levelEnd.Show(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name), "Fall to your death...\nRestart?");
        }
    }

    private void CollectedCoin()
    {
        coinsCollected++;
        if (coinsCollected >= coins.Length)
        {
            if (lastLevel)
            {
                levelEnd.Show(() => SceneManager.LoadScene("Level 1"), "THE END\n THANKS FOR PLAYING\n Play again?");
            }
            else
            {
                levelEnd.Show(() => SceneManager.LoadScene(nextLevel), "Go to the next level?");
            }
        }
    }

    private void LevelFaild()
    {
        levelEnd.Show(() => SceneManager.LoadScene(SceneManager.GetActiveScene().name), "Stop right there crimrnal!\nRestart?");
    }
}