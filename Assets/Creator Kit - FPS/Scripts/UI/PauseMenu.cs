using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance { get; private set; }
    public GameObject m_SelectLevel;
    public GameObject m_PauseLevel;

    void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
        m_SelectLevel.SetActive(false);
    }

    public void Display()
    {
        gameObject.SetActive(true);
        GameSystem.Instance.StopTimer();
        Controller.Instance.DisplayCursor(true);
    }

    public void OpenEpisode()
    {
        
        m_SelectLevel.SetActive(true);
        // if(LevelSelectionUI.Instance.IsEmpty())
        //     return;
        
        UIAudioPlayer.PlayPositive();
        //gameObject.SetActive(false);
        // LevelSelectionUI.Instance.DisplayEpisode();
    }

    public void ReturnToGame()
    {
        UIAudioPlayer.PlayPositive();
        GameSystem.Instance.StartTimer();
        gameObject.SetActive(false);
        m_PauseLevel.gameObject.SetActive(false);
        m_SelectLevel.gameObject.SetActive(false);
        Controller.Instance.DisplayCursor(false);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
