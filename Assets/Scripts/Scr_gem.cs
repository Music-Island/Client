using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_gem : MonoBehaviour
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
            player_control pc = other.GetComponent<player_control>();
            if ( pc.is_atking() )
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
