using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    [SerializeField] TMPro.TextMeshProUGUI goldTMP;

    public ScriptableInt GlobalGold;

    private void OnEnable()
    {
        SetCurrentGold();
    }

    void SetCurrentGold()
    {
        var player = GameObject.FindObjectOfType<Player>();

        int point = (int)player.ScaleObject.transform.localScale.y * 10;

        goldTMP.text = (point).ToString() + " GOLD";

        GlobalGold.IncreaseValue(point);
    }
}
