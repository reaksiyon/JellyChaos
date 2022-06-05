using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{
    [SerializeField] float point = 1;

    public void OnCollect()
    {
        Player.OnPointCollect?.Invoke(point);

        if (PowerUpController.Instance != null)
            PowerUpController.Instance.AddExp(0.1f);
        else
            Debug.LogError("PLEASE START THE GAME FROM Game-Scene !");
    }
}
