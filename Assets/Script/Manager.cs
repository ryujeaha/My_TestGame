using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour
{
    Save_Data save_Data;
    Player player;
    public Text Stage_txt;
    public Text Beef_txt;

    public int Enemy_Count = 0;
    public BigInteger Beef = 0;
    public int stage_Level = 1;

    // Start is called before the first frame update
    void Start()
    {
        save_Data = FindObjectOfType<Save_Data>();
        save_Data.LoadData();
        player = FindObjectOfType<Player>();
        Stage_txt.text = "Stage " + stage_Level.ToString();
        Beef_txt.text = "얻은 소고기 수:" + BeefUp(Beef);
    }

    // Update is called once per frame
    void Update()
    {
        StageUP();
    }

    void StageUP()
    {
        Beef_txt.text = "얻은 소고기 수: " + BeefUp(Beef);
        if (Enemy_Count >= stage_Level * 20)
        {
            stage_Level++;
            Stage_txt.text = "Stage " + stage_Level.ToString();
            Enemy_Count = 0;
            save_Data.SaveData();
        }
    }
    public int Set_Cow_hp()
    {
        int Cow_hp = (int)Get_cost(10, 10, 1.06f, stage_Level) * 2;
        return Cow_hp;
    }

    public BigInteger Get_cost(int b, int k, float r, int n)
    {
        BigInteger cost;
        cost = (BigInteger)(b * ((Mathf.Pow(r, k) - Mathf.Pow(r, k + n)) / (1 - r)));
        //Debug.Log(string.Format("b: {0}, k : {1}, r:{2}, n:{3}, total : {4}", b, k, r, n, cost));
        return cost;
    }

    public void Money()
    {
        Beef += Get_cost(10, 10, 1.06f, stage_Level);
        Beef_txt.text = "얻은 소고기 수 :" + BeefUp(Beef);
        Enemy_Count++;
    }
    public string BeefUp(BigInteger _beef)
    {
        string value = _beef.ToString();
        if (value.Trim().Length <= 3)
        {
            value = _beef + "개";
        }
        else if (value.Trim().Length > 3 && value.Trim().Length <= 6)
        {
            value = (Beef / 1000) + "K개";
        }
        else if (value.Trim().Length > 6 && value.Trim().Length <= 9)
        {
            value = (Beef / 1000000) + "M개";
        }
        else if (value.Trim().Length > 9 && value.Trim().Length <= 12)
        {
            value = (Beef / 1000000000) + "B개";
        }
        else if (value.Trim().Length > 12 && value.Trim().Length <= 15)
        {
            value = (Beef / 1000000000000) + "T개";
        }
        else if (value.Trim().Length > 15)
        {
            value = value.Substring(0, 1) + "." + value.Substring(1, 2) + "E개" + (value.Length - 1);
        }
        return value;
    }

    public void Game_retry()
    {
       save_Data.LoadData();
       SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
       player.GameOver.SetActive(false);
    }
}
