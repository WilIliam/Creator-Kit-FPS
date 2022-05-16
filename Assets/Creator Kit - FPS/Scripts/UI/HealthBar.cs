/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    #region Variables

    public Slider m_Slider;
    public Gradient m_Gradient;
    public Image m_FillImage;
    public Image m_Blood;

    Animator m_Animatior;
    #endregion

    void Start(){
        m_Animatior = m_Blood.GetComponent<Animator>();
    }

    void Update(){
        
    }

    #region Class

    public void SetMaxHealth(int health)
    {
        m_Slider.maxValue = health;
        m_Slider.value = health;
        
        m_FillImage.color = m_Gradient.Evaluate(1f);
    }

    public void setHealth(int health)
    {
        m_Slider.value = health;
        m_FillImage.color = m_Gradient.Evaluate(m_Slider.normalizedValue);
        m_Animatior.SetTrigger("isTouch");
        Debug.Log("Health is " + health);
    }
    #endregion
}
