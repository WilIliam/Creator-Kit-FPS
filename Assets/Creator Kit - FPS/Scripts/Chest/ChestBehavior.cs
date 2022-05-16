/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehavior : MonoBehaviour
{

    #region Variables

    public GameObject m_FloatingTextPrefab;
    public GameObject m_FloatingTextAmmoPrefab;
    public GameObject m_Player;
    public bool isNear = false;
    public float m_Distance = 3f;

    public int m_SupplyAmmount = 20;
    [SerializeField]
    int m_CurrentSupplyAmmount = 100;
    Transform m_PlayerPosition;
    string m_CurrentAmmoInChest;
    #endregion

    #region Unity Mehods

    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_PlayerPosition = m_Player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        m_FloatingTextAmmoPrefab.GetComponentInChildren<TextMesh>().text = m_SupplyAmmount.ToString() + " / " + m_CurrentSupplyAmmount.ToString();
        NearPlayer();
    }


    #endregion

    #region Class

    void NearPlayer()
    {
        if (Vector3.Distance(transform.position, m_PlayerPosition.position) < m_Distance)
        {
            m_FloatingTextPrefab.gameObject.SetActive(true);
            m_FloatingTextPrefab.transform.LookAt(m_PlayerPosition);
            isNear = true;
            //Debug.Log("Player is near");
        }
        else
        {
            m_FloatingTextPrefab.gameObject.SetActive(false);
            isNear = false;
        }
    }

    public int ReloadAmmo()
    {
        m_CurrentSupplyAmmount -= m_SupplyAmmount;

        if (m_CurrentSupplyAmmount <= 0)
        {
            m_SupplyAmmount = 0;
        }

        return m_SupplyAmmount;
    }

    #endregion
}
