/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
#endif

public class StartMenu : MonoBehaviour
{

    #region Variables
    public static StartMenu Instance { get; private set; }
    public GameObject m_SelectLevel;
    #endregion

    #region Unity Mehods

    void Awake()
    {
        Instance = this;
        gameObject.SetActive(true);
        m_SelectLevel.SetActive(false);
    }

    #endregion

    #region Class

    public void StartGame()
    {
        UIAudioPlayer.PlayPositive();
        gameObject.SetActive(false);
        SceneManager.LoadScene("ExampleScene");
    }

    public void OpenEpisode()
    {
        UIAudioPlayer.PlayPositive();
        gameObject.SetActive(false);
        m_SelectLevel.gameObject.SetActive(true);
        m_SelectLevel.gameObject.SetActive(true);
    }


    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    #endregion
}
