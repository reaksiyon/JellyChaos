using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class JellyTarget : Enemy
{
    [Header("Move Transforms")]

    [SerializeField] Transform startPoint;

    [SerializeField] Transform endPoint;


    [Header("Initialization")]

    [SerializeField] bool isMoving = false;

    [SerializeField] GameObject movingObject;

    [SerializeField] float speed = 1f;


    TMPro.TextMeshPro DamageTMP;

    bool isReachedToEnd = false;

    private void Start()
    {
        DamageTMP = GetComponentInChildren<TMPro.TextMeshPro>();

        DamageTMP.text = "-" + damage.ToString();

        movingObject.transform.position = startPoint.position;

        Move();
    }

    void Move()
    {
        if (!isMoving) return;

        if (!isReachedToEnd)
        {
            isReachedToEnd = true;

            movingObject.transform.DOMove(endPoint.position, 1f / speed).OnComplete(() => Move()).SetEase(Ease.Linear);
        }
        else
        {
            isReachedToEnd = false;

            movingObject.transform.DOMove(startPoint.position, 1f / speed).OnComplete(() => Move()).SetEase(Ease.Linear);
        }

    }

}
