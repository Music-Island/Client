using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MovePrefab : MonoBehaviour
{
    public GameObject m_prefab;
    public float m_Speed = 10.0f;
    //float tp = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //tp += UnityEngine.Time.deltaTime;
        //if (gameObject.transform.localPosition.x >= 0)
        //{
        //    print(tp);
        //}
        float fMoveSpeed = m_Speed * UnityEngine.Time.deltaTime;
        m_prefab.transform.position += Vector3.left * fMoveSpeed;
    }
}
