using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    [SerializeField] Transform targetTransform;

    private void Update()
    {
        transform.localPosition = targetTransform.localPosition + (Vector3.up * 1.2f);
    }
}
