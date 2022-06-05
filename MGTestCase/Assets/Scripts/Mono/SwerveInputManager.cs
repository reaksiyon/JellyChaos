using UnityEngine;
using System;
public class SwerveInputManager : MonoBehaviour
{
    public static Action OnTouchReleased;
    float lastFrameFingerPosition;
    float moveFactorX;
    public float MoveFactorX => moveFactorX;
    float referenceScreenWidth = 540;

    public float HalfLaneSize = 3;

    private void Awake()
    {
        Instance = this;
    }

    private void Update() 
    {

        if(Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPosition = Input.mousePosition.x;
        }
        else if(Input.GetMouseButton(0))
        {

            moveFactorX = (Input.mousePosition.x - lastFrameFingerPosition) / Screen.width * referenceScreenWidth;
            //moveFactorX = (Input.mousePosition.x - lastFrameFingerPosition);
            if(Mathf.Approximately(moveFactorX, 0))
                moveFactorX = 0;
            //Debug.Log("Move factor x: " + moveFactorX);
            lastFrameFingerPosition = Input.mousePosition.x;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0;
            OnTouchReleased?.Invoke();
        }
    }

    public static SwerveInputManager Instance;
}
