using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour
{
    public GameObject settingPanel;

    public void ClickStart()
    {
        SceneManager.LoadScene("Intro");
    }

    public void ClickSetting()
    {
        settingPanel.SetActive(true);
    }

    public void ClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ClickSkip()
    {
        SceneManager.LoadScene("Main");
    }
}
