using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private string finishTag = "Finish";
    [SerializeField] private string nextLevel = "Level";
    [SerializeField] private GameObject boom = null;
    [SerializeField] private Rigidbody player = null;

    private bool alive = true;


    private void Update()
    {
        if (player.position.y < -20 && alive)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            alive = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(finishTag))
        {
            alive = false;
            StartCoroutine(EndLevel(player.position));
        }
    }
    public IEnumerator EndLevel(Vector3 pos)
    {
        var _ = Instantiate(boom, pos, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(nextLevel);
    }
}
