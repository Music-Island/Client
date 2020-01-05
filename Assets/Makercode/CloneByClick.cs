using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneByClick : MonoBehaviour
{
    public string key;
    public GameObject prefab, obj;
    public float x, y, z;
    static float timeSpend = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeSpend += UnityEngine.Time.deltaTime;
    } 
    void OnGUI()
    {
        if (Input.anyKeyDown)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                if (string.Equals(e.keyCode.ToString(), key) && timeSpend > 0.1)
                {
                    float a = GameObject.Find("Grid").transform.localPosition.x;
                    float b = GameObject.Find("Grid").transform.localPosition.y;
                    float c = GameObject.Find("Grid").transform.localPosition.z;
                    obj = Instantiate(prefab) as GameObject;
                    obj.transform.position = new Vector3(a + x, y, z);
                    obj.GetComponent<InCamera>().clone = true;
                    timeSpend = 0.0f;
                }
            }
        }
    } 

}
