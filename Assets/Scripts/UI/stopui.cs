using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stopui : MonoBehaviour
{
    public PlayerController play;
    public TweenColor change;
    public UISlider hpslider;
    public GameObject cancelus;
    public GameObject submitus;
    public GameObject exit;
    public TweenScale cancel;
    public TweenColor mengban;
    public GameObject start;
    public UILabel sc;
    public UILabel hit;
    public TweenScale hittween;
    public GameObject stoppanel;
    //bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        hittween.PlayForward();
    }

    // Update is called once per frame
    void Update()
    {
        showhit();
        showsc();
        showHP();
        /*if (flag == true)
        {
            play.pause();
            //flag = 0;
        }
        else if (flag == false)
        {
            play.play();
            //flag = 0;
        }*/
    }
    
    public void Stoppanel()
    {

        //        exit.SetActive(true);
        stoppanel.SetActive(true);
        //cancel.PlayForward();
        mengban.PlayForward();
        exit.SetActive(false);
        start.SetActive(true);
        play.pause();
        //flag = true;
        
        /*cancelus.SetActive(true);
        submitus.SetActive(true);*/
        //hpslider.value = (float)(val/100.0);
        //.enabled(ture);
        //GameObject.Find("exit").GetComponent<Animator>().enabled = true;
    }
    public void Stophide()
    {
        play.play();
        exit.SetActive(true);
        start.SetActive(false);
        mengban.PlayReverse();
        //cancel.PlayReverse();
        stoppanel.SetActive(false);
        //flag = false;
        
        /*cancelus.SetActive(false);
        submitus.SetActive(false);*/
    }
    public void change_scene()
    {
        SceneManager.LoadScene("final");
    }
    public void skip()
    {
        change.PlayForward();
    }
    public void showsc()
    {
        string tem = play.getSC().ToString();
        if (tem != sc.text)
        {
            sc.text = tem;
        }
    }
    public void showhit()
    {
        string tem = play.getCombo().ToString();
        if (tem != hit.text)
        {
            hit.text = tem;
        }
    }
    public void showHP()
    {
        hpslider.value = (float)(play.getHP() / 100.0);
    }
}
