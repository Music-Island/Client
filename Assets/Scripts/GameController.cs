using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameController instance;
    public Text TextHp;
    public Text TextSc;
    public Image Hurt_Image;
    private Color flashColour=new Color(1, 0, 0, 0.8f);
    private float flashSpeed =5.0f;

    private bool hurt=false;
    int curHP = 10;
    int curSC = 0;
    private void Awake()
    {
        if ( instance==null )
        {
            instance = this;
        }else if ( instance!=this )
        {
            Destroy(gameObject);
        }

    }
    void Start()
    {
        TextHp.text = "HP: " + curHP.ToString();
        TextSc.text = "SC: " + curSC.ToString();
        Hurt_Image.color= new Color(1f, 1f, 1f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if ( hurt )
        {
            Hurt_Image.color= flashColour;

        }
        else
        {
            Hurt_Image.color = Color.Lerp(Hurt_Image.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        hurt = false;
    }
    public void Now_hurt()
    {
        hurt = true;
    }
    public void UpdataAndDisplayHp(int val)
    {
        curHP += val;
        TextHp.text = "HP: "+curHP.ToString();
    }
    public void UpdataAndDisplaySc(int val)
    {
        curSC += val;
        TextSc.text = "SC: " + curSC.ToString();
    }

}
