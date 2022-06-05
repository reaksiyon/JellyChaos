using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGoldSetter : MonoBehaviour
{
    [SerializeField] ScriptableInt GlobalGold;
    [SerializeField] TMPro.TextMeshProUGUI globalGoldTMP;
    void Update()
    {
        globalGoldTMP.text = GlobalGold.GetValue().ToString();
    }
}
