
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class ForwardMovement : MonoBehaviour
{
    Rigidbody rb;

    public float initialSpeed;

    [SerializeField] float currentSpeed;

    [SerializeField] bool isMoving;

    [SerializeField] UnityEvent onStartMoving;

    //public SwipeInputManager swipeMovement;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        currentSpeed = initialSpeed;

        SetMovement(false);
    }

    public void Update()
    {
        // if(GameStateManager.Instance.BonusActive) return;

        if (Input.GetMouseButtonDown(0))
        {
            SetMovement(true);

            onStartMoving?.Invoke();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            SetMovement(true);
            //SetMovement(false); if we want to move our character with out touching
        }
    }

    void FixedUpdate()
    {
        if (rb == null) return;

        if (isMoving)
        {
            var vel = rb.velocity;

            vel.z = currentSpeed;

            rb.velocity = vel;

            //rb.AddForce(Vector3.forward * Time.deltaTime * speed, ForceMode.Impulse);
            //rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * speed);
        }
    }

    public void SetMovement(bool value)
    {
        isMoving = value;
    }


    public void SetSpeed(float value, bool initial = false)
    {
        if (initial)
        {
            initialSpeed = value;

            currentSpeed = value;
        }
        else
            currentSpeed = value;
    }

    public void SetSpeed(float value)
    {
        currentSpeed = value;
    }

    public void ToggleMovement()
    {
        isMoving = !isMoving;
    }
}
