using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject WinPanel;

    public GameObject LosePanel;

    public GameObject PlayTipPanel;

    public GameObject BoostPanel;

    private void Awake()
    {
        Instance = this;
    }

    public static PanelManager Instance;
}
