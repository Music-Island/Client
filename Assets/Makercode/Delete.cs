using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    GameObject[] sno1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void delete()
    {
        sno1 = GameObject.FindGameObjectsWithTag("Fire");
        foreach (GameObject item in sno1)
        {
            bool islook = item.GetComponent<InCamera>().isLook;
            if (islook == true)
                Destroy(item);
        }
    }
}
