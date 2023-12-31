using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMinimap : MonoBehaviour
{
    [SerializeField] private bool x, y, z;  // 이 값이 true면 target의 좌표, false면 좌표를 사용.
    [SerializeField] private Transform target;
    private Vector3 offset;
    public float smoothness = 1.0f;
    private void Start()
    {
        offset = new Vector3(0, 10, 0);
    }

    private void Update()
    {
        if(target == null)
        {
            return;
        }

        Vector3 desirePos = target.position + offset;
        Vector3 pos = Vector3.Lerp(transform.position, desirePos, smoothness);
        transform.position = pos;
    }
}
