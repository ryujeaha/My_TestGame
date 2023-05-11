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
            costText.text = "�ʿ��� �Ұ��" + cost + "��";
        }
        else
        {
            if(gun.Gun_LV == manager.stage_Level)
            {
                costText.text = "�ʿ��� �Ұ��" + cost + "��";
                cost = manager.Get_cost(18, 10, 1.01f, gun.Gun_LV) * manager.stage_Level;//���� �� �ִ� ���� ���������� �ö󰡸� ���� 2�� + óġ���� 2��� 4�谡 �ö󰡱� ������
            }
            else
            {
                costText.text = "�ʿ��� �Ұ��" + cost + "��";
                cost = manager.Get_cost(18, 10, 1.01f, gun.Gun_LV) * ((manager.stage_Level)-1);//���� �� �ִ� ���� ���������� �ö󰡸� ���� 2�� + óġ���� 2��� 4�谡 �ö󰡱� ������
            }
           
        }
    }
        
}
