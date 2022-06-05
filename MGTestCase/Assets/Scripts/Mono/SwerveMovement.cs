using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SwerveMovement : MonoBehaviour
{
    [SerializeField] float swerveSpeed = 1;
    [SerializeField] float mobileSwerveSpeed = 16f;
    [SerializeField] float maxSwerveAmount = 1f;
    [SerializeField] bool stopRbOnTouchRelease = true;
    bool CanMoveLeft = true;
    bool CanMoveRight = true;
    bool swerveEnabled = true;

    private void Update()
    {
        // if (GameManager.Instance.isFinish) return;
        Movement();
    }
    void Movement()
    {
        if (SwerveInputManager.Instance.MoveFactorX < 1 && SwerveInputManager.Instance.MoveFactorX > -1) return;
        if (!swerveEnabled) return;

        float swerveAmount = swerveSpeed * SwerveInputManager.Instance.MoveFactorX * Time.deltaTime ;

        swerveAmount = Mathf.Clamp(swerveAmount, -maxSwerveAmount, maxSwerveAmount);
        var position = transform.localPosition;


        if (position.x > SwerveInputManager.Instance.HalfLaneSize)
        {
            position.x = SwerveInputManager.Instance.HalfLaneSize;
            transform.localPosition = position;
            CanMoveRight = false;
        }
        else if (position.x < -SwerveInputManager.Instance.HalfLaneSize)
        {
            position.x = -SwerveInputManager.Instance.HalfLaneSize;
            transform.localPosition = position;
            CanMoveLeft = false;
        }

        if (position.x < SwerveInputManager.Instance.HalfLaneSize - 0.1f && !Mathf.Approximately(position.x, SwerveInputManager.Instance.HalfLaneSize))
        {
            CanMoveRight = true;
        }
        if (position.x > -SwerveInputManager.Instance.HalfLaneSize + 0.1f && !Mathf.Approximately(position.x, -SwerveInputManager.Instance.HalfLaneSize))
        {
            CanMoveLeft = true;
        }
        Swerve(swerveAmount);
        // {
        //     if (position.x < SwerveInputManager.Instance.HalfLaneSize - 0.1f && !Mathf.Approximately(position.x, SwerveInputManager.Instance.HalfLaneSize))
        //     {
        //         CanMoveRight = true;
        //     }
        //     if (position.x > -SwerveInputManager.Instance.HalfLaneSize + 0.1f && !Mathf.Approximately(position.x, -SwerveInputManager.Instance.HalfLaneSize))
        //     {
        //         CanMoveLeft = true;
        //     }
        //     Swerve(swerveAmount);
        // }
    }

    protected void Swerve(float swerveAmount)
    {
        if (Mathf.Approximately(swerveAmount, 0)) return;
        if ((swerveAmount > 0 && !CanMoveRight) || (swerveAmount < 0 && !CanMoveLeft)) return;
        Vector3 targetPos = transform.localPosition;
        targetPos.x += swerveAmount;

#if UNITY_EDITOR
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, swerveSpeed*Time.deltaTime);
#else
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, mobileSwerveSpeed*Time.deltaTime);
#endif
    }

    public void ToggleSwerve(bool value)
    {
        swerveEnabled = value;
    }
}
