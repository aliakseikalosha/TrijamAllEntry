using System;
using UnityEngine;

public class SpotTrigger : MonoBehaviour, IEnterable<Player>
{
    private Action onEntred;
    public void Init(Action onEntred)
    {
        this.onEntred = onEntred;
    }
    public void OnEnter(Player other)
    {
        onEntred?.Invoke();
    }
}
