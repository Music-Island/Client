using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_apple : MonoBehaviour
{
    public float hspeed = 5f;//垂直方向的速度
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
           
            Destroy(this.gameObject);
        }
    }
        // Update is called once per frame
    void Update()
    {
        Vector2 P = transform.position;
        P.x -= hspeed * Time.deltaTime;
        transform.position = P;

    }
}
