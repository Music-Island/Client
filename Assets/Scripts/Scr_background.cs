using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_background : MonoBehaviour
{
    private int speed = 10;
    public GameObject T;
    // Start is called before the first frame update
    void Start()
    {
        T = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 P=T.transform.position;
        if (P.x <=-10)
            P.x = 10f;
        P.x -= speed * Time.deltaTime;
        T.transform.position = P;

    }
}
