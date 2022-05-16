/*
* Create by William (c)
* https://github.com/Long18
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyScript : MonoBehaviour
{

    #region Variables

    public float m_Distance;
    public float m_Speed;
    public int m_Damage;
    public GameObject m_Player;

    private Transform m_PlayerPosition;
    private Vector3 m_CurrentPosition;

    Controller m_PlayerController;
    #endregion

    #region Unity Mehods

    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_PlayerController = m_Player.GetComponent<Controller>();
        m_PlayerPosition = m_Player.GetComponent<Transform>();
        m_CurrentPosition = GetComponent<Transform>().position;

    }

    // Update is called once per frame
    void Update()
    {
        FollowingPlayer();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_PlayerController.TakeDamage(m_Damage);
            // Debug.Log("Player is touched");
        }
    }

    #endregion

    #region Class

    void FollowingPlayer()
    {
        // Distance between the player and the enemy
        // If the distance is less than the distance, the enemy will follow the player
        try
        {
            if (Vector3.Distance(transform.position, m_PlayerPosition.position) < m_Distance)
            {
                transform.position = Vector3.MoveTowards(transform.position, m_PlayerPosition.position, m_Speed * Time.deltaTime);
                transform.LookAt(m_PlayerPosition);
            }
            else
            {
                if (Vector3.Distance(transform.position, m_CurrentPosition) < 0)
                {
                    m_CurrentPosition = m_PlayerPosition.position;
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, m_CurrentPosition, m_Speed * Time.deltaTime);
                    transform.LookAt(m_CurrentPosition);
                }

            }
        }
        catch (NullReferenceException e)
        {
            Debug.Log(e.Message);
        }




    }

    #endregion
}
