using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class End : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Button()
    {
        GameObject[] sno1;
        string txt = "";
        Text names = GameObject.Find("AudioPanel").GetComponent<AudioPlayer>().audioName;
        sno1 = GameObject.FindGameObjectsWithTag("Fire");
        foreach(GameObject item in sno1)
        {
            int type = -1;
            if (item.name == "Roadblock(Clone)") type = 1;
            else if (item.name == "Plane(Clone)") type = 2;
            else if (item.name == "EnemyAll(Clone)") type = 3;
            float a = item.transform.localPosition.x;
            string str = type.ToString() + " " + a.ToString();
            if (type != -1)txt += str + "\n";
         }
        StreamWriter F = new StreamWriter(names.text + ".txt", false);
        F.Write(txt);
        F.Close();
    }
}
