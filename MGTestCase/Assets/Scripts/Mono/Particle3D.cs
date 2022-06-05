using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Particle3D : MonoBehaviour
{
    void Update()
    {
        transform.Translate(-Vector3.up * (Time.deltaTime * 10));
    }

}
