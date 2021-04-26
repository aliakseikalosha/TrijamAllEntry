using System;
using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour, IEnterable<Player>
{
    public Action OnCollected;
    [SerializeField] private Character character;
    [SerializeField] private float floatHeight = 1f;
    [SerializeField] private float animationTime = 1f;

    private void Awake()
    {
        StartCoroutine(Floating());
    }

    private IEnumerator Floating()
    {
        var start = character.Transform.position;
        while (true)
        {
            float time = 0;
            while (time < 1)
            {
                time += Time.deltaTime / animationTime;
                character.Transform.position = start + Mathf.Cos(time * Mathf.PI * 2) * floatHeight * Vector3.up;
                yield return null;
            }
        }
    }

    public void OnEnter(Player other)
    {
        OnCollected?.Invoke();
        Destroy(gameObject);
    }
}
