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
        costText.text = "필요한 소고기"+cost+"개";
        cost = manager.Get_cost(50, 10, 1.07f, gun.Gun_LV);
    }
}
