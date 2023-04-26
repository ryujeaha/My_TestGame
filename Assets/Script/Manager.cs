using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public Text Stage_txt;
    public Text Beef_txt;


    public int Enemy_Count = 0;
    public BigInteger Beef = 0;
    public int stage_Level = 1;
    // Start is called before the first frame update
    void Start()
    {
        Stage_txt.text = "Stage" + stage_Level.ToString();
        Beef_txt.text = "���� �Ұ�� ��:" + BeefUp(Beef);
    }

    // Update is called once per frame
    void Update()
    {
        if(Enemy_Count >= 30)
        {
            stage_Level++;
            Stage_txt.text = "Stage" + stage_Level.ToString();
            Enemy_Count = 0;
            ;        }
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
        Beef_txt.text = "���� �Ұ�� �� :" + BeefUp(Beef);
        Enemy_Count++;
    }


    public string BeefUp(BigInteger _beef)
    {
        string value = _beef.ToString();
        if (value.Trim().Length <= 3)
        {
            value = _beef + "��";
        }
        else if (value.Trim().Length > 3 && value.Trim().Length <= 6)
        {
            value = (Beef / 1000) + "K��";
        }
        else if (value.Trim().Length > 6 && value.Trim().Length <= 9)
        {
            value = (Beef / 1000000) + "M��";
        }
        else if (value.Trim().Length > 9 && value.Trim().Length <= 12)
        {
            value = (Beef / 1000000000) + "B��";
        }
        else if (value.Trim().Length > 12 && value.Trim().Length <= 15)
        {
            value = (Beef / 1000000000000) + "T��";
        }
        else if (value.Trim().Length > 15)
        {
            value = value.Substring(0, 1) + "." + value.Substring(1, 2) + "E��" + (value.Length - 1);
        }
        return value;
    }
}
