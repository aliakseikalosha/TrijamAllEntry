using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    public Action OnCoughtPlayer;
    [SerializeField] private Transform[] path;
    [SerializeField] private Light spotlight;
    [SerializeField] private LayerMask targetLayers;
    [SerializeField] private float radius = 2;
    [SerializeField] private SpotTrigger trigger;

    private void Awake()
    {
        StartCoroutine(FollowPath());
        trigger.Init(() => OnCoughtPlayer?.Invoke());
    }

    private IEnumerator FollowPath()
    {
        int index = 1;
        var spotlightTransform = spotlight.transform;
        spotlightTransform.LookAt(path[0].position);
        while (true)
        {
            float time = 0;
            var start = path[index - 1].position;
            var end = path[index].position;
            while (time < 1)
            {
                time += Time.deltaTime / 5f;
                var target = Vector3.Lerp(start, end, time);
                spotlightTransform.LookAt(target);
                trigger.transform.position = target;
                yield return null;
            }
            index = Mathf.Max(1, (++index) % path.Length);
        }
    }
}
