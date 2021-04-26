using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Camera gameCamera;
    [SerializeField] private Transform target;

    private void Update()
    {
        target.LookAt(gameCamera.transform);
    }

}
