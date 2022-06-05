using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float damage = 0.25f;

    public void Attack()
    {
        Player.OnPointLose(damage);
    }

}
