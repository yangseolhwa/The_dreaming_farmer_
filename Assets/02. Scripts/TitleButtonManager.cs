using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TitleButtonController : MonoBehaviour
{
    public GameObject settingPanel;

    public void ClickStart()
    {
        SceneManager.LoadScene("Main");
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
}
