using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnStart : MonoBehaviour
{
    [SerializeField] private string startSceneName = "Level 1";
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene(startSceneName);
    }
}
