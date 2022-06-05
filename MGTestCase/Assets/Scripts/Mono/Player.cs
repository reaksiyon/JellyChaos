using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public static Action<float> OnPointCollect;

    public static Action<float> OnPointLose;

    [Header("Player")]
    [SerializeField] Transform playerModel;

    [SerializeField] Transform playerTransformPoint;

    [SerializeField] Animator PlayerAnimator;

    [SerializeField] Animator scaleAnimator;

    [Header("Settings")]
    [SerializeField] ForwardMovement forwardMovement;

    public GameObject ScaleObject;

    [SerializeField] float scaleTime = .2f;

    [SerializeField] TMPro.TextMeshPro sizeTextTMP;

    bool isDead = false;

    private void OnEnable()
    {
        OnPointCollect += IncreaseSize;

        OnPointLose += DecreaseSize;
    }

    private void OnDisable()
    {
        OnPointCollect -= IncreaseSize;

        OnPointLose -= DecreaseSize;
    }

    private void Update()
    {
        playerModel.position = playerTransformPoint.position;

        sizeTextTMP.text = ScaleObject.transform.localScale.y.ToString("0.00");
    }

    public void IncreaseSize(float val)
    {
        if (isDead) return;

        ScaleObject.transform.DOScaleY(ScaleObject.transform.localScale.y + val, scaleTime);

        scaleAnimator.SetTrigger("resize");
    }

    public void DecreaseSize(float val)
    {
        if (isDead) return;
        //Debug.Log("Val: " + val + ", My Local Scale: " + scaleObject.transform.localScale.y); 
        
        ScaleObject.transform.DOScaleY(ScaleObject.transform.localScale.y - val, scaleTime);

        scaleAnimator.SetTrigger("resize");

        CheckState(ScaleObject);
    }

    private void CheckState(GameObject scaleObject)
    {
        if(scaleObject.transform.localScale.y < 0.3f)
        {
            Death();

            isDead = true;
        }
    }

    public void Death()
    {
        forwardMovement.SetSpeed(0);

        PanelManager.Instance.LosePanel.SetActive(true);

        PlayerAnimator.SetTrigger("defeat");
    }
}
