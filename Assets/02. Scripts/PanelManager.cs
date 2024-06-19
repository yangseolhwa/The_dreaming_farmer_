using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    GameObject panel;

    public void ShowPanel()
    {
        panel.SetActive(true);
    }

    public void HidePanel()
    {
        panel.SetActive(false);
    }
}
