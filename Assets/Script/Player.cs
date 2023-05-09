using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Player_HP = 3;
    public int HP_Cnt = 0;
    public Image[] HP_IMG;
    public GameObject GameOver;
    // Update is called once per frame
    void Update()
    {
        if(Player_HP <= 0)
        {
            Dead();
        }
    }
    void Dead()
    {
        Sound_Manager.instance.SetBgm(0);
        Time.timeScale = 0.001f;
        GameOver.SetActive(true);
    }
}
