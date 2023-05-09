using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gun : MonoBehaviour
{
    public Animator anim;

    public Text Lv;
    public Transform[] target;
    public GameObject Shot;
    public float Atk_Speed=0;
    public float Cooltime = 0;

    public int Gun_LV = 1;

    bool ready_shot;
    void Start()
    {
        ready_shot = true;
    }

    private void Update()
    {
        Cooltime_set();
        Spawn_Shot();
    }

    public void Cooltime_set()
    {
        Atk_Speed = Mathf.Sqrt(Gun_LV) / Gun_LV;
        Cooltime -= Time.deltaTime;
        if(Cooltime <= 0)
        {
            ready_shot = true;
            Cooltime = Atk_Speed;          
        }
    }

    void Spawn_Shot()
    {
        Lv.text ="현재 레벨: "+Gun_LV.ToString();
        if (ready_shot)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))//오른쪽 클릭
            {
                Shot_Effect(2);
                Sound_Manager.instance.PlaySound("Shot_Sound", 1);
                GameObject shot = (GameObject)Instantiate(Shot, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, -45));
                shot.GetComponent<Shot>().Set_Goal(2, target[2].transform);
                ready_shot = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))//왼쪽 클릭
            {
                Shot_Effect(0);
                Sound_Manager.instance.PlaySound("Shot_Sound", 1);
                GameObject shot = (GameObject)Instantiate(Shot, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.Euler(0, 0, 45));
                shot.GetComponent<Shot>().Set_Goal(0, target[0].transform);
                ready_shot = false;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))//위쪽 클릭
            {
                Shot_Effect(1);
                Sound_Manager.instance.PlaySound("Shot_Sound", 1);
                GameObject shot = (GameObject)Instantiate(Shot, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
                shot.GetComponent<Shot>().Set_Goal(1, target[1].transform);
                ready_shot = false;
            }
        }
    }
    void Shot_Effect(int num)
    {
        if(num == 0)
        {
            anim.SetTrigger("Left");
        }
       else if (num == 1)
        {
            anim.SetTrigger("Mid");
        }
        else if (num == 2)
        {
            anim.SetTrigger("Right");
        }

    }
}
