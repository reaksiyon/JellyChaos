using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    public void LevelCompleted()
    {
        PanelManager.Instance.WinPanel.SetActive(true);

        PanelManager.Instance.BoostPanel.SetActive(false);

        var player = GameObject.FindObjectOfType<Player>();

        player.GetComponentInChildren<ForwardMovement>().SetSpeed(0f);

        player.GetComponentInChildren<Animator>().SetTrigger("win");
    }
}
