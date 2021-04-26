using UnityEngine;

public interface IEnterable<T> where T : MonoBehaviour
{
    void OnEnter(T other);
}
