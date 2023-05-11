using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEngine.UI;
public class Lv_up : MonoBehaviour
{
    Manager manager;
    Gun gun;
    BigInteger cost;
    public Text costText;

    private void Start()
    {
        manager = FindObjectOfType<Manager>();
        gun = FindObjectOfType<Gun>();
    }

    public void Lv_Up()
    {
        if (manager.Beef >= cost)
        {
            manager.Beef -= cost;
            gun.Gun_LV++;
        }
    }

    private void Update()
    {
        Lv_Cost();
    }

    void Lv_Cost()
    { 
        if(gun.Gun_LV == 1)
        {
            cost = manager.Get_cost(18, 10, 1.01f, gun.Gun_LV);
            costText.text = "필요한 소고기" + cost + "개";
        }
        else
        {
            if(gun.Gun_LV == manager.stage_Level)
            {
                costText.text = "필요한 소고기" + cost + "개";
                cost = manager.Get_cost(18, 10, 1.01f, gun.Gun_LV) * manager.stage_Level;//얻을 수 있는 돈이 스테이지가 올라가면 몹수 2배 + 처치보상 2배로 4배가 올라가기 때문에
            }
            else
            {
                costText.text = "필요한 소고기" + cost + "개";
                cost = manager.Get_cost(18, 10, 1.01f, gun.Gun_LV) * ((manager.stage_Level)-1);//얻을 수 있는 돈이 스테이지가 올라가면 몹수 2배 + 처치보상 2배로 4배가 올라가기 때문에
            }
           
        }
    }
        
}
