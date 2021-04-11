using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableRigidbody : MonoBehaviour
{
    [SerializeField] private Rigidbody body = null;
    [SerializeField] private LayerMask ground;

    private bool draging;
    public Vector3 screenSpace;
    public Vector3 offset;

    private Vector3 destinationPosition
    {
        get
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100, ground))
            {
                return hit.point;
            }
            return body.position;
        }
    }

    private GameObject GetClickedObject(out RaycastHit hit)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            return hit.collider.gameObject;
        }
        return null;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (body.gameObject == GetClickedObject(out _))
            {
                draging = true;
                screenSpace = Camera.main.WorldToScreenPoint(transform.position);
                offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            draging = false;
        }
        if (draging)
        {
            var direction = (destinationPosition - body.position);
            direction = direction.normalized;
            direction.y = 0;
            body.velocity += direction.normalized;
            var velocityHorizontal = body.velocity;
            velocityHorizontal.y = 0;
            if (velocityHorizontal.sqrMagnitude > 25)
            {
                var newVelocity = velocityHorizontal.normalized * 5;
                newVelocity.y = body.velocity.y;
                body.velocity = newVelocity;
            }
        }
    }
}
