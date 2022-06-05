using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] int levelCount = 2;

    [SerializeField] ScriptableInt currentLevel;

    private void Start()
    {
        LoadCurrentScene();

        ScriptableData.OnInitialized?.Invoke();
    }

    public void NextLevel()
    {
        SceneManager.UnloadScene("Level " + currentLevel.Value.ToString());


        currentLevel.IncreaseValue(1);

        if (currentLevel.GetValue() > levelCount)
            currentLevel.UpdateValue(1);

        RestartScene();
    }

    public void LoadCurrentScene()
    {
        if (SceneManager.sceneCount > 1)
            SceneManager.UnloadScene("Level " + currentLevel.Value.ToString());

        SceneManager.LoadScene("Level " + currentLevel.Value.ToString(), LoadSceneMode.Additive);

        SceneLevelTextSetter.OnLevelStart?.Invoke();
    }

    [ContextMenu("Restart Scene")]
    public void RestartScene()
    {
        PanelManager.Instance.WinPanel.SetActive(false);

        PanelManager.Instance.LosePanel.SetActive(false);

        PanelManager.Instance.PlayTipPanel.SetActive(true);

        LoadCurrentScene();
    }

}
