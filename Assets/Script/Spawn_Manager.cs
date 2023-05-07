using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject Cow;//받을 적 소 캐릭터 프리펩
    public GameObject[] Spawns;//스폰포인트들을 담을 배열변수

    Manager manager;

    private void Start()
    {
        manager = FindObjectOfType<Manager>();
        InvokeRepeating("Spawn_Cow",1,1);
    }

    void Spawn_Cow()
    {
        int Spawn = Random.Range(0, 3);//어디서 스폰 할 것인지 위치 정하기 변수
        if(Spawn != 2)
        {
            GameObject cow = (GameObject)Instantiate(Cow, new Vector2(Spawns[Spawn].transform.position.x, Spawns[Spawn].transform.position.y), Quaternion.identity);
            cow.GetComponent<Cow_Enemy>().Cow_Hp = manager.Set_Cow_hp();
        }
        else
        {
            GameObject cow = (GameObject)Instantiate(Cow, new Vector2(Spawns[Spawn].transform.position.x, Spawns[Spawn].transform.position.y), Quaternion.identity);
            cow.transform.localScale = new Vector3(-0.35f, 0.35f, 1f);
            cow.GetComponent<Cow_Enemy>().Cow_Hp = manager.Set_Cow_hp();
        }
        

    }
}
