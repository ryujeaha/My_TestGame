using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Numerics;

public class PlayerData
{
    public int Player_LV;
    public int Stage_LV;
    public string Beef;
    public int HP;
    public int HP_cnt;

    public void SetData(Manager m,Gun g,Player p)
    {
        m.stage_Level = Stage_LV;
        m.Beef = BigInteger.Parse(Beef);
        g.Gun_LV = Player_LV;
        p.HP_Cnt = HP_cnt;
        p.Player_HP = HP;
        for(int i=0;i < HP_cnt; i++)
        {
            p.HP_IMG[i].gameObject.SetActive(false);
        }
    }
}


public class Save_Data : MonoBehaviour
{
    Manager manager;
    Gun gun;
    Player player;

    BigInteger Beef;

    private void Awake()
    {   
        Debug.Log(Application.persistentDataPath);
        manager = FindObjectOfType<Manager>();
        gun = FindObjectOfType<Gun>();
        player = FindObjectOfType<Player>();
    }

    public void SaveData()
    {
        PlayerData mydata = new PlayerData();
        mydata.Stage_LV = manager.stage_Level;
        mydata.Player_LV = gun.Gun_LV;
        mydata.Beef = manager.Beef.ToString();
        mydata.HP = player.Player_HP;
        mydata.HP_cnt = player.HP_Cnt;
        string str = JsonUtility.ToJson(mydata);

        Debug.Log(str);

        File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", JsonUtility.ToJson(mydata));
        
    }
    public void LoadData()//str을 받음(외부에서)
    {
        try
        {
            string jsonData = File.ReadAllText(Application.persistentDataPath + "/PlayerData.json");

            PlayerData data2 = JsonUtility.FromJson<PlayerData>(jsonData);//데이터 로드
            data2.SetData(manager, gun, player);

        }
        catch (Exception)
        {
            SaveData();
        }
    }
}
