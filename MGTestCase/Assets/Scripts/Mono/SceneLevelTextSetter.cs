using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLevelTextSetter : MonoBehaviour
{
    [SerializeField] ScriptableInt currentLevel;

    public static Action OnLevelStart;

    private void OnEnable()
    {
        OnLevelStart += SetLevelText;
    }

    private void OnDisable()
    {
        OnLevelStart -= SetLevelText;
    }

    void Start()
    {
        SetLevelText();
    }

    public void SetLevelText()
    {
        var LevelTMP = GetComponentInChildren<TMPro.TextMeshProUGUI>();
        LevelTMP.text = "Level " + currentLevel.GetValue();
    }

}
