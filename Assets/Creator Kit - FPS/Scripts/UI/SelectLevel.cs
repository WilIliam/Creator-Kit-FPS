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

public class SelectLevel : MonoBehaviour
{

    #region Variables
    public static SelectLevel Instance { get; private set; }

    public GameObject m_StartMenu;
    #endregion

    #region Unity Mehods

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        m_StartMenu.SetActive(false);
    }


    #endregion

    #region Class
    public void StartLevelOne()
    {
        UIAudioPlayer.PlayPositive();
        SceneManager.LoadScene("ExampleScene");
    }
    public void StartLevelTwo()
    {
        UIAudioPlayer.PlayPositive();
        SceneManager.LoadScene("Level 1");
    }
    public void StartLevelThree()
    {
        UIAudioPlayer.PlayPositive();
        SceneManager.LoadScene("Last Level");
    }

    public void BackToMenu(){
        UIAudioPlayer.PlayNegative();
        gameObject.SetActive(false);
        SceneManager.LoadScene("StartMenu");
    }
    #endregion
}
