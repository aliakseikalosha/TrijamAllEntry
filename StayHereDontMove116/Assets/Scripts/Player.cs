using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private KeyCode[] forward = { KeyCode.W, KeyCode.UpArrow };
    [SerializeField] private KeyCode[] left = { KeyCode.A, KeyCode.LeftArrow };
    [SerializeField] private KeyCode[] right = { KeyCode.D, KeyCode.RightArrow };
    [SerializeField] private KeyCode[] backward = { KeyCode.S, KeyCode.DownArrow };
    [SerializeField] private Character character;

    private bool Pressed(KeyCode[] keys)
    {
        foreach (var key in keys)
        {
            if (Input.GetKey(key))
            {
                return true;
            }
        }
        return false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            character.Jump();
        }
        var dir = Vector3.zero;
        if (Pressed(forward))
        {
            dir.z += 1;
        }
        if (Pressed(backward))
        {
            dir.z -= 1;
        }
        if (Pressed(right))
        {
            dir.x += 1;
        }
        if (Pressed(left))
        {
            dir.x -= 1;
        }
        character.Move(dir);
    }

    private void OnTriggerEnter(Collider other)
    {
        var entrable = other.GetComponent<IEnterable<Player>>();
        if (entrable != null)
        {
            entrable.OnEnter(this);
        }
    }
}