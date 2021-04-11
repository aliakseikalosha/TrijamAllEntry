using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConroller : MonoBehaviour
{
    [SerializeField] private KeyCode rotateRight = KeyCode.E;
    [SerializeField] private KeyCode rotateLeft = KeyCode.Q;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform target;

    private float offset;
    private void Awake()
    {
        offset = (mainCamera.transform.position - target.position).sqrMagnitude;
    }
    private void Update()
    {
        if (Input.GetKeyDown(rotateLeft))
        {
            Rotate(45f);
        }
        if (Input.GetKeyDown(rotateRight))
        {
            Rotate(-45f);
        }
    }
    private void LateUpdate()
    {
        if ((mainCamera.transform.position - target.position).sqrMagnitude > offset)
        {
            mainCamera.transform.position = (mainCamera.transform.position - target.position  ).normalized * Mathf.Sqrt(offset);
        }
    }

    private void Rotate(float v)
    {
        mainCamera.transform.RotateAround(target.position, Vector3.up, v);
    }
}

