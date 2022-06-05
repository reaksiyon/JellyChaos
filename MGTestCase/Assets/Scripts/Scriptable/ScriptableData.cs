using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public abstract class ScriptableData : ScriptableObject
{
    public abstract object Value { get; protected set; }

    [SerializeField] protected SaveToggleable saveData;

    protected string saveKey { get { return saveData.SaveKey; } }

    public Action OnValueUpdated;

    public static Action OnInitialized;

    private void OnValidate()
    {
        OnValueUpdated?.Invoke();
    }

    private void OnEnable()
    {
        OnInitialized += Initialize;
    }

    private void OnDisable()
    {
        OnInitialized -= Initialize;
    }

    public void Initialize()
    {
        if (saveData.Enabled && HasKey())
            Load();
    }

    public void UpdateValue(ScriptableData data)
    {
        UpdateValue(data.Value);
    }

    protected virtual void IncreaseValue(ScriptableData data) { }
    protected virtual void DecreaseValue(ScriptableData data) { }

    public virtual void UpdateValue(object value, bool callUpdated = true)
    {
        if (Value == value) return;

        Value = value;

        if (callUpdated)
            OnValueUpdated?.Invoke();

        if (saveData.Enabled)
            Save();
    }

    public void Save()
    {
        if (HasKey())
        {
            var json = JsonConvert.SerializeObject(Value);

            PlayerPrefs.SetString(saveKey, json);
            // PlayerPrefs.Save();
        }
    }
    protected bool HasKey()
    {
        if (string.IsNullOrEmpty(saveKey))
        {
            Debug.LogError(name + " SaveKey is empty");

            return false;
        }
        else
            return true;
    }

    public abstract void Load();

    public void CallUpdate()
    {
        UpdateValue(Value);
    }

    [Serializable]
    protected class SaveToggleable
    {
        public bool Enabled;

        public string SaveKey;
    }

}
