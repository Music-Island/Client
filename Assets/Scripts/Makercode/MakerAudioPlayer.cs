using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using System.IO;

[RequireComponent(typeof(AudioSource))]

public class MakerAudioPlayer : MonoBehaviour
{
    //==================组件
    public AudioClip audioClip;
    public Text audioTime;
    public Text audioName;
    public Slider audioTimeSlider;
    public Button pauseButton;
    public Button playButton;
    public Button stopButton;
    public AudioSource audioSource;
    public string changefile;
    //====================当前时间/总时间
    private int currentHour;
    private int currentMinute;
    private int currentSecond;
        //===总
    private int clipHour;
    private int clipMinute;
    private int clipSecond;
    private bool flag = false;
    private int cnt = 0;

    void Start()
    {
        changefile = "";
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioName.text = audioClip.name;
        clipHour = (int)audioSource.clip.length / 3600;
        clipMinute = (int)(audioSource.clip.length - clipHour * 3600) / 60;
        clipSecond = (int)(audioSource.clip.length - clipHour * 3600 - clipMinute * 60);
        //================= 事件监听
        audioTimeSlider.onValueChanged.AddListener(
            (delegate
            {
                SetAudioTimeBySliderValueChange();
            }
            ));
        pauseButton.onClick.AddListener(
            (delegate
            {
                AudioPause();
            }
            ));
        playButton.onClick.AddListener(
            (delegate
            {
                AudioPlay();
            }
            ));
        stopButton.onClick.AddListener(
            (delegate
            {
                AudioStop();
            }
            ));
    }
    void Update()
    {
        if (flag)
        {
            UpdateSliderValue();
            clipHour = (int)audioClip.length / 3600;
            clipMinute = (int)(audioClip.length - clipHour * 3600) / 60;
            clipSecond = (int)(audioClip.length - clipHour * 3600 - clipMinute * 60);
        }
        if (changefile.Length != 0)
        {
            StartCoroutine(LoadMusic(changefile));
            flag = true;
            sstart();
        }
    }

    //=====================随着音乐播放不断更新滑动条
    private void UpdateSliderValue()
    {
        currentHour = (int)audioSource.time / 3600;
        currentMinute = (int)( audioSource.time - currentHour * 3600 ) / 60;
        currentSecond = (int)( audioSource.time - currentHour * 3600 - currentMinute * 60 );
        audioTime.text = string.Format("{0:D2}:{1:D2}:{2:D2} / {3:D2}:{4:D2}:{5:D2}",
            currentHour, currentMinute, currentSecond, clipHour, clipMinute, clipSecond);
        audioTimeSlider.value = audioSource.time / audioClip.length;
    }
    //================通过滑动条改变音乐时间
    private void SetAudioTimeBySliderValueChange()
    {
        audioSource.time = audioTimeSlider.value * audioSource.clip.length;
        GameObject obj = GameObject.Find("Grid");
        float y = obj.transform.localPosition.y;
        float z = obj.transform.localPosition.z;
        float x = audioSource.time * (float)10.0;
        obj.transform.position = new Vector3(x, y, z);
    }
    private void AudioPause()
    {
        audioSource.Pause();
    }
    
    private void AudioPlay()
    {
        audioSource.Play();
    }

    private void AudioStop()
    {
        audioSource.Stop();
    }
    void sstart()
    {
        //audioSource = GetComponent<AudioSource>();
        //audioSource.clip = audioClip;
        clipHour = (int)audioClip.length / 3600;
        clipMinute = (int)(audioClip.length - clipHour * 3600) / 60;
        clipSecond = (int)(audioClip.length - clipHour * 3600 - clipMinute * 60);
        string[] Split = changefile.Split(new char[] { '\\','/'});
        int len = Split.Length;
        audioName.text = Split[len - 1].Replace(".wav", "");
        changefile = "";
    }
    private IEnumerator LoadMusic(string filepath)
    {
        filepath = "file:///" + filepath;
        using (var uwr = UnityWebRequestMultimedia.GetAudioClip(filepath, AudioType.WAV))
        {
            yield return uwr.SendWebRequest();
            if (uwr.isNetworkError)
            {
                Debug.LogError(uwr.error);
            }
            else
            {
                AudioClip clip = DownloadHandlerAudioClip.GetContent(uwr);
                // use audio clip
                audioClip = clip;
                audioSource.clip = clip;
            }
        }
    }
}