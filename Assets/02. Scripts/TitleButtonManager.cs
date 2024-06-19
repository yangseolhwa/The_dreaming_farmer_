using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleButtonManager : MonoBehaviour
{
    PanelManager panelManager = new PanelManager();

    public void ClickStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void ClickSetting()
    {
        panelManager.ShowPanel();
    }

    public void ClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
