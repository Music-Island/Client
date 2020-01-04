using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;
using System.Reflection;

public class CameraTest : MonoBehaviour
{
    public WebCamTexture cameraTexture;
    public Transform plane;
    public string cameraName = "";
    private bool isPlay = false;
    // Use this for initialization  

    // Update is called once per frame  
    void Update()
    {

    }
    /// <summary>  
    /// 获取权限打开摄像头  
    /// </summary>  
    /// <returns></returns>  
    IEnumerator OpenCamera()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            WebCamDevice[] devices = WebCamTexture.devices;
            cameraName = devices[0].name;
            cameraTexture = new WebCamTexture(cameraName, 320, 240, 15);
            cameraTexture.Play();
            isPlay = true;
        }
    }

    void Start()
    {
        if (isPlay)
        {
            GUI.DrawTexture(new Rect(0, 0, 500, 500), cameraTexture, ScaleMode.ScaleAndCrop);
        }

        //if (GUI.Button(new Rect(0, 0, 100, 35), "OpenDialog"))
        //{
            OpenFileName ofn = new OpenFileName();

            ofn.structSize = Marshal.SizeOf(ofn);

            //ofn.filter = "All Files\0*.*\0\0";
            ofn.filter = "All Files\0*.*\0\0";
            ofn.file = new string(new char[256]);

            ofn.maxFile = ofn.file.Length;

            ofn.fileTitle = new string(new char[64]);

            ofn.maxFileTitle = ofn.fileTitle.Length;
            string path = Application.streamingAssetsPath;
            //path = path.Replace('/', '\\');
            //默认路径  
            ofn.initialDir = path;
            //ofn.initialDir = "D:\\MyProject\\UnityOpenCV\\Assets\\StreamingAssets";  
            ofn.title = "Open Project";

            ofn.defExt = "WAV";//显示文件的类型  
            //注意 一下项目不一定要全选 但是0x00000008项不要缺少  
            ofn.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000200 | 0x00000008;//OFN_EXPLORER|OFN_FILEMUSTEXIST|OFN_PATHMUSTEXIST| OFN_ALLOWMULTISELECT|OFN_NOCHANGEDIR  

            if (WindowDll.GetOpenFileName(ofn))
            {
                StartCoroutine(WaitLoad(ofn.file));     //加载图片到panle


                //GameObject.Find("AudioPanel").GetComponent<AudioPlayer>().audioClip = ofn.file;
                Debug.Log("Selected file with full path: {0}" + ofn.file);
            }

        //}
    }

    IEnumerator WaitLoad(string fileName)
    {
        var wwwTexture = new WWW("file://" + fileName);

        Debug.Log(wwwTexture.url);

        yield return wwwTexture;

        GameObject.Find("AudioPanel").GetComponent<AudioPlayer>().changefile = fileName;

    }
}