using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableInt")]
public class ScriptableInt : ScriptableData
{
    [SerializeField] int value;
    public override object Value { get { return value; } protected set { this.value = (int)value; } }

    public int GetValue() => (int)Value;

    public void IncreaseValue(ScriptableInt v)
    {
        IncreaseValue(v.value);
    }

    public void MultiplyValue(ScriptableInt v)
    {
        MultiplyValue(v.value);
    }

    public void DivideValue(ScriptableInt v)
    {
        DivideValue(v.value);
    }

    public void IncreaseValue(int v)
    {
        UpdateValue(value + v);
    }

    public void DecreaseValue(ScriptableInt v)
    {
        DecreaseValue(v.value);
    }

    public void DecreaseValue(int v)
    {
        UpdateValue(value - v);
    }

    public void MultiplyValue(int v)
    {
        UpdateValue(value * v);
    }

    public void DivideValue(int v)
    {
        UpdateValue(value / v);
    }

    public override void UpdateValue(object value, bool callUpdated = true)
    {
        base.UpdateValue(value);
    }

    public override void Load()
    {
        if (PlayerPrefs.HasKey(saveKey))
        {
            var loadData = JsonConvert.DeserializeObject<int>(PlayerPrefs.GetString(saveKey, ""));
            UpdateValue(loadData);
        }
    }

}
