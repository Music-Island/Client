using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InCamera : MonoBehaviour
{
    public bool isLook = false;
    public bool clone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (pos.x < 0 || pos.x > 1 || pos.y < 0 || pos.y > 1)
        {
            isLook = false;
        }
        else
        {
            isLook = true;
        }
    }
}
