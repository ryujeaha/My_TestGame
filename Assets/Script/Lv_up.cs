using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv_up : MonoBehaviour
{
    Manager manager;
    Gun gun;

    private void Start()
    {
        manager = FindObjectOfType<Manager>();
        gun = FindObjectOfType<Gun>();
    }

    public void Lv_Up()
    {
        if (manager.Beef >= manager.Get_cost(50, 10, 1.07f, gun.Gun_LV))
        {
            manager.Beef -= manager.Get_cost(50, 10, 1.07f, gun.Gun_LV);
            gun.Gun_LV++;
        }
    }
}
