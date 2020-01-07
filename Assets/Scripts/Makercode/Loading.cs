using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class Loading : MonoBehaviour
{
    public GameObject obj, prefab1, prefab2, prefab3;
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
        GameObject[] sno1 = GameObject.FindGameObjectsWithTag("Fire");
        foreach (GameObject item in sno1)
        {
            if (item.GetComponent<InCamera>().clone)
                Destroy(item);
        }
        Text names = GameObject.Find("AudioPanel").GetComponent<MakerAudioPlayer>().audioName;
        string dir = "./song/" + names.text;
        if (!Directory.Exists(dir))//如果不存在就
            return;
        StreamReader F = new StreamReader(dir + "/" + names.text + ".txt");
        string str = F.ReadLine();
        while(str != null)
        {
            string[] split = str.Split(new char[] { ' ', '\n' });
            int type = int.Parse(split[0]);
            float x = float.Parse(split[1]);
            float y = 0;
            float z = 0;
            if (type == 1)
            {
                obj = Instantiate(prefab1) as GameObject;
                y = GameObject.Find("New Sprite 1").GetComponent<CloneByClick>().y;
                z = GameObject.Find("New Sprite 1").GetComponent<CloneByClick>().y;
            }
            else if (type == 2)
            {
                obj = Instantiate(prefab2) as GameObject;
                y = GameObject.Find("New Sprite 2").GetComponent<CloneByClick>().y;
                z = GameObject.Find("New Sprite 2").GetComponent<CloneByClick>().y;
            }
            else if (type == 3)
            {
                obj = Instantiate(prefab3) as GameObject;
                y = GameObject.Find("New Sprite 3").GetComponent<CloneByClick>().y;
                z = GameObject.Find("New Sprite 3").GetComponent<CloneByClick>().y;
            }
            obj.transform.position = new Vector3(x, y, z);
            obj.GetComponent<InCamera>().clone = true;
            str = F.ReadLine();
        }
        F.Close();
    }
}
