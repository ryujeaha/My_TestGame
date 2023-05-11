using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject Cow;//���� �� �� ĳ���� ������
    public GameObject[] Spawns;//��������Ʈ���� ���� �迭����

    Manager manager;

    public float spawn_cooltime;
    public float cooltime;
    private void Start()
    {
        manager = FindObjectOfType<Manager>();
        cooltime = 1;
    }

    public void SpawnCool()
    {
        spawn_cooltime = Mathf.Sqrt(manager.stage_Level/ manager.stage_Level);
        cooltime -= Time.deltaTime;
        if(cooltime <= 0)
        {
            cooltime -= Time.deltaTime;
            Spawn_Cow();
            cooltime = spawn_cooltime;
        }
    }

    private void Update()
    {
        SpawnCool();
    }
    void Spawn_Cow()
    {
        
        int Spawn = Random.Range(0, 3);//��� ���� �� ������ ��ġ ���ϱ� ����
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
